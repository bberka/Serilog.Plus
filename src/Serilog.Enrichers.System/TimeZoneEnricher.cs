using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class TimeZoneEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public TimeZoneEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var timeZone = TimeZoneInfo.Local;
    var property = propertyFactory.CreateProperty(_propertyName, timeZone);
    logEvent.AddOrUpdateProperty(property);
  }
}