using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestQueryStringEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public HttpRequestQueryStringEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var queryString = httpContext?.Request?.QueryString;
    if (!queryString.HasValue) return;
    var property = propertyFactory.CreateProperty(_propertyName, queryString.Value);
    logEvent.AddOrUpdateProperty(property);
  }
}