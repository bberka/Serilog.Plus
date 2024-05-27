using Serilog.Configuration;

namespace Serilog.Enrichers.HttpRequest;

public static class SerilogEnrichersHttpRequestExtensions
{
  public static LoggerConfiguration WithHttpRequestAllHeaders(this LoggerEnrichmentConfiguration enrich) {
    return enrich.With(new HttpRequestAllHeadersEnricher());
  }

  public static LoggerConfiguration WithHttpRequestClaim(this LoggerEnrichmentConfiguration enrich, string propertyName, string claimType) {
    return enrich.With(new HttpRequestClaimEnricher(propertyName, claimType));
  }

  public static LoggerConfiguration WithHttpRequestHeader(this LoggerEnrichmentConfiguration enrich, string propertyName, string headerName) {
    return enrich.With(new HttpRequestHeaderEnricher(propertyName, headerName));
  }


  public static LoggerConfiguration WithHttpRequestId(this LoggerEnrichmentConfiguration enrich, string propertyName = "RequestId") {
    return enrich.With(new HttpRequestIdEnricher(propertyName));
  }

  public static LoggerConfiguration WithHttpRequestIpAddress(this LoggerEnrichmentConfiguration enrich, string propertyName = "IpAddress", string realIpHeader = "") {
    return enrich.With(new HttpRequestIpAddressEnricher(propertyName, realIpHeader));
  }

  public static LoggerConfiguration WithHttpRequestMethod(this LoggerEnrichmentConfiguration enrich, string propertyName = "RequestMethod") {
    return enrich.With(new HttpRequestMethodEnricher(propertyName));
  }

  public static LoggerConfiguration WithHttpRequestPath(this LoggerEnrichmentConfiguration enrich, string propertyName = "RequestPath") {
    return enrich.With(new HttpRequestPathEnricher(propertyName));
  }


  public static LoggerConfiguration WithHttpRequestProtocol(this LoggerEnrichmentConfiguration enrich, string propertyName = "Protocol") {
    return enrich.With(new HttpRequestProtocolEnricher(propertyName));
  }

  public static LoggerConfiguration WithHttpRequestQueryString(this LoggerEnrichmentConfiguration enrich, string propertyName = "QueryString") {
    return enrich.With(new HttpRequestQueryStringEnricher(propertyName));
  }

  
  public static LoggerConfiguration WithHttpRequestRole(this LoggerEnrichmentConfiguration enrich, string propertyName = "UserRole") {
    return enrich.With(new HttpRequestRoleEnricher(propertyName));
  }
  
  public static LoggerConfiguration WithHttpRequestScheme(this LoggerEnrichmentConfiguration enrich, string propertyName = "Scheme") {
    return enrich.With(new HttpRequestSchemeEnricher(propertyName));
  }

  public static LoggerConfiguration WithHttpRequestTradeIdentifier(this LoggerEnrichmentConfiguration enrich, string propertyName = "TradeIdentifier") {
    return enrich.With(new HttpRequestSchemeEnricher(propertyName));
  }
  
  public static LoggerConfiguration WithHttpRequestUserAgent(this LoggerEnrichmentConfiguration enrich, string propertyName = "UserAgent") {
    return enrich.With(new HttpRequestUserAgentEnricher(propertyName));
  }


  public static LoggerConfiguration WithHttpRequestUserIdentityName(this LoggerEnrichmentConfiguration enrich, string propertyName = "UserIdentityName") {
    return enrich.With(new HttpRequestUserIdentityNameEnricher(propertyName));
  }

}