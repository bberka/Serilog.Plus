using System.Net.NetworkInformation;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class MacAddressEnricher : ILogEventEnricher
{
  private static string _macAddress = string.Empty;
  private readonly bool _getOnlyActive;
  private readonly bool _getSingle;
  private readonly string _propertyName;

  public MacAddressEnricher(string propertyName, bool getSingle, bool getOnlyActive) {
    _propertyName = propertyName;
    _getSingle = getSingle;
    _getOnlyActive = getOnlyActive;
    if (string.IsNullOrEmpty(_macAddress)) {
      _macAddress = GetMacAddress();
    }
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var property = propertyFactory.CreateProperty(_propertyName, _macAddress);
    logEvent.AddOrUpdateProperty(property);
  }

  private string GetMacAddress() {
    var networks = NetworkInterface.GetAllNetworkInterfaces();
    if (_getOnlyActive)
      networks = networks
                 .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                 .ToArray();
    var macAddressList = networks.Select(network => network.GetPhysicalAddress().ToString()).Where(macAddress => !string.IsNullOrEmpty(macAddress)).ToList();
    if (_getSingle) return macAddressList.FirstOrDefault() ?? string.Empty;
    return string.Join(",", macAddressList);
  }
}