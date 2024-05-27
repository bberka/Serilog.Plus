using Microsoft.Win32;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class MachineGuidEnricher : ILogEventEnricher
{
  private static string? _machineGuid;
  private readonly string _propertyName;

  public MachineGuidEnricher(string propertyName) {
    _propertyName = propertyName;
    _machineGuid ??= GetMachineGuid();
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var property = propertyFactory.CreateProperty(_propertyName, _machineGuid);
    logEvent.AddOrUpdateProperty(property);
  }

  private string GetMachineGuid() {
    var location = @"SOFTWARE\Microsoft\Cryptography";
    var name = "MachineGuid";
    using var localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
    using var rk = localMachineX64View.OpenSubKey(location);
    if (rk == null) return "-";
    // throw new KeyNotFoundException("Cannot find the key: " + location);
    var machineGuid = rk.GetValue(name);
    if (machineGuid == null) return "-";
    // throw new IndexOutOfRangeException("Cannot find the value: " + name);
    return machineGuid.ToString()?.ToUpper() ?? string.Empty;
  }
}