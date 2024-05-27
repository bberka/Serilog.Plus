using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestUserAgentEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public HttpRequestUserAgentEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();
    if (userAgent == null) return;
    var userAgentProperty = propertyFactory.CreateProperty(_propertyName, userAgent);
    logEvent.AddPropertyIfAbsent(userAgentProperty);
  }
}