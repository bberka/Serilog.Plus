using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestHeaderEnricher : ILogEventEnricher
{
  private readonly string _headerName;
  private readonly string _propertyName;

  public HttpRequestHeaderEnricher(string propertyName, string headerName) {
    _propertyName = propertyName;
    _headerName = headerName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var header = httpContext?.Request?.Headers[_headerName];
    if (!header.HasValue) return;
    var property = propertyFactory.CreateProperty(_propertyName, header ?? "-");
    logEvent.AddOrUpdateProperty(property);
  }
}