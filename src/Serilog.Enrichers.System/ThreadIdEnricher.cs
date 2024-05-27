using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class ThreadIdEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public ThreadIdEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var threadId = Environment.CurrentManagedThreadId;
    var property = propertyFactory.CreateProperty(_propertyName, threadId);
    logEvent.AddOrUpdateProperty(property);
  }
}