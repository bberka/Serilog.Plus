using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class MachineNameEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public MachineNameEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var machineName = Environment.MachineName;
    var property = propertyFactory.CreateProperty(_propertyName, machineName);
    logEvent.AddOrUpdateProperty(property);
  }
}