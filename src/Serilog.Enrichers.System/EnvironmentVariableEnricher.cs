using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.System;

internal sealed class EnvironmentVariableEnricher : ILogEventEnricher
{
  private readonly string _environmentVariableName;
  private readonly string _propertyName;

  public EnvironmentVariableEnricher(string propertyName, string environmentVariableName) {
    _propertyName = propertyName;
    _environmentVariableName = environmentVariableName;
  }

  public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
    var environment = Environment.GetEnvironmentVariable(_environmentVariableName);
    if (environment == null) return;
    var property = propertyFactory.CreateProperty(_propertyName, environment);
    logEvent.AddOrUpdateProperty(property);
  }
}