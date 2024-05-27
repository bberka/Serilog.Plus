using System.Security.Claims;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

internal sealed class HttpRequestRoleEnricher : ILogEventEnricher
{
  private readonly string _propertyName;

  public HttpRequestRoleEnricher(string propertyName) {
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var httpContext = new HttpContextAccessor().HttpContext;
    var roleClaim = httpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role);
    if (roleClaim == null) return;
    var property = propertyFactory.CreateProperty(_propertyName, roleClaim);
    logEvent.AddOrUpdateProperty(property);
  }
}