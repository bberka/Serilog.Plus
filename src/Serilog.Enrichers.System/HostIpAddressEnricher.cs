using System.Net;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class HostIpAddressEnricher : ILogEventEnricher
{
  private static string? _hostIpAddress;
  private readonly string _propertyName;

  public HostIpAddressEnricher(string propertyName) {
    _propertyName = propertyName;
    _hostIpAddress ??= GetHostIpAddress();
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var property = propertyFactory.CreateProperty(_propertyName, _hostIpAddress);
    logEvent.AddOrUpdateProperty(property);
  }


  private static string GetHostIpAddress() {
    var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
    var ipAddress = ipHostInfo.AddressList.Select(x => x.ToString())
                              .Where(x => !x.StartsWith("192.168.") && !x.StartsWith("::"))
                              .ToList();
    return ipAddress.FirstOrDefault() ?? string.Empty;
  }
}