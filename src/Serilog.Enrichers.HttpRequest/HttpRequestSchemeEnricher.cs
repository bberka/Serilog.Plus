using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestSchemeEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public HttpRequestSchemeEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var scheme = httpContext?.Request?.Scheme;
    if (scheme == null) return;
    var property = propertyFactory.CreateProperty(_propertyName, scheme);
    logEvent.AddOrUpdateProperty(property);
  }
}