using System.Diagnostics;
using System.Text;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class StackTraceEnricher : ILogEventEnricher
{
  private readonly bool _includeFileName;
  private readonly bool _includeNameSpace;
  private readonly string _propertyName;

  public StackTraceEnricher(string propertyName, bool includeNameSpace = false, bool includeFileName = true) {
    _includeNameSpace = includeNameSpace;
    _includeFileName = includeFileName;
    _propertyName = propertyName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var property = propertyFactory.CreateProperty(_propertyName, GetStackTraceString());
    logEvent.AddOrUpdateProperty(property);
  }

  public string GetStackTraceString() {
    var stackTrace = new StackTrace(true);
    var frames = stackTrace.GetFrames();
    var stringBuilder = new StringBuilder();
    foreach (var frame in frames) {
      var method = frame.GetMethod();
      var declaringType = method?.DeclaringType;
      if (declaringType is null) continue;
      var methodName = method?.Name;
      var strBase = $"{methodName}";
      if (_includeFileName) {
        var fileName = Path.GetFileName(declaringType.Assembly.Location);
        strBase = $"{fileName}.{strBase}";
      }

      if (_includeNameSpace) {
        var nameSpaceName = declaringType.Namespace ?? string.Empty;
        strBase = $"{nameSpaceName}.{strBase}";
      }

      stringBuilder.Append(strBase);
      stringBuilder.Append(" -> ");
    }

    var removeLast = stringBuilder.ToString().LastIndexOf(" -> ", StringComparison.Ordinal);
    stringBuilder.Remove(removeLast, 4);
    return stringBuilder.ToString().Trim();
  }
}