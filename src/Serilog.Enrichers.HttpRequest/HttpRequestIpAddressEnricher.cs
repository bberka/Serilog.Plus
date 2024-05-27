using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestIpAddressEnricher : ILogEventEnricher
{
  private readonly string _propertyName;
  private readonly string _realIpHeader;


  public HttpRequestIpAddressEnricher(string realIpHeader, string propertyName) {
    _propertyName = propertyName;
    _realIpHeader = realIpHeader;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var remoteIpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();
    if (!string.IsNullOrEmpty(_realIpHeader)) {
      var realIp = httpContext?.Request?.Headers[_realIpHeader].ToString();
      if (!string.IsNullOrEmpty(realIp)) remoteIpAddress = realIp;
    }

    if (string.IsNullOrEmpty(remoteIpAddress)) return;
    var property = propertyFactory.CreateProperty(_propertyName, remoteIpAddress);
    logEvent.AddOrUpdateProperty(property);
  }
}