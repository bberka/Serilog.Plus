using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestTraceIdentifierEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public HttpRequestTraceIdentifierEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var traceId = httpContext?.TraceIdentifier;
    if (traceId == null) return;
    var property = propertyFactory.CreateProperty(_propertyName, traceId);
    logEvent.AddOrUpdateProperty(property);
  }
}