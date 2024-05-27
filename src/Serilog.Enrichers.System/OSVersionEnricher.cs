using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class OSVersionEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public OSVersionEnricher(string propertyName) {
    _propertyName = propertyName;
  }


  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var osVersion = Environment.OSVersion.ToString();
    var property = propertyFactory.CreateProperty(_propertyName, osVersion);
    logEvent.AddOrUpdateProperty(property);
  }
}