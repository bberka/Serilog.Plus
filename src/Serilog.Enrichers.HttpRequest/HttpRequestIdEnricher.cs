using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestIdEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public HttpRequestIdEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var requestId = httpContext?.Connection?.Id;
    if (requestId == null) return;
    var property = propertyFactory.CreateProperty(_propertyName, requestId);
    logEvent.AddOrUpdateProperty(property);
  }
}