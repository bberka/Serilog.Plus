using Serilog.Configuration;

namespace Serilog.Enrichers.System;

public static class EnricherExtensions
{
  public static LoggerConfiguration WithEnvironmentVariable(this LoggerEnrichmentConfiguration enrich, string propertyName, string environmentVariableName) {
    return enrich.With(new EnvironmentVariableEnricher(propertyName, environmentVariableName));
  }


  public static LoggerConfiguration WithHostIpAddress(this LoggerEnrichmentConfiguration enrich, string propertyName = "HostIpAddress") {
    return enrich.With(new HostIpAddressEnricher(propertyName));
  }

  public static LoggerConfiguration WithMacAddress(
    this LoggerEnrichmentConfiguration enrich,
    string propertyName = "MacAddress",
    bool getSingle = true,
    bool getOnlyActive = true) {
    var machineGuidEnricher = new MacAddressEnricher(propertyName, getSingle, getOnlyActive);
    return enrich.With(machineGuidEnricher);
  }

  public static LoggerConfiguration WithMachineGuid(this LoggerEnrichmentConfiguration enrich, string propertyName = "MachineGuid") {
    return enrich.With(new MachineGuidEnricher(propertyName));
  }

  public static LoggerConfiguration WithMachineName(this LoggerEnrichmentConfiguration enrich, string propertyName = "MachineName") {
    return enrich.With(new MachineNameEnricher(propertyName));
  }

  public static LoggerConfiguration WithOSVersion(this LoggerEnrichmentConfiguration enrich, string propertyName = "OSVersion") {
    return enrich.With(new OSVersionEnricher(propertyName));
  }

  public static LoggerConfiguration WithStackTrace(this LoggerEnrichmentConfiguration enrich, string propertyName = "StackTrace") {
    return enrich.With(new StackTraceEnricher(propertyName));
  }

  public static LoggerConfiguration WithThreadId(this LoggerEnrichmentConfiguration enrich, string propertyName = "ThreadId") {
    return enrich.With(new ThreadIdEnricher(propertyName));
  }

  public static LoggerConfiguration WithTimeZone(this LoggerEnrichmentConfiguration enrich, string propertyName = "TimeZone") {
    return enrich.With(new TimeZoneEnricher(propertyName));
  }
}