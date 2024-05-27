using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.HttpRequest;

/// <summary>
///     Enriches Serilog messages with the all header values in current HttpRequest.
/// </summary>
internal sealed class HttpRequestAllHeadersEnricher : ILogEventEnricher
{
  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var context = new HttpContextAccessor().HttpContext;
    var headers = context?.Request?.Headers;
    if (headers is null) return;
    foreach (var item in headers) {
      var property = propertyFactory.CreateProperty("Header:" + item.Key, item.Value);
      logEvent.AddOrUpdateProperty(property);
    }
  }
}