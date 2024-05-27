

# Serilog.Plus
Contains enricher libraries for Serilog

# Serilog.Enrichers.HttpRequest
Enrich serilog events with HttpRequest information.

Install the Serilog.Enrichers.HttpRequest NuGet package
```
Install-Package Serilog.Enrichers.HttpContext
```
OR
```
dotnet add package Serilog.Enrichers.HttpContext
```

## HttpRequest Enricher Methods

- WithHttpRequestAllHeaders
- WithHttpRequestClaim
- WithHttpRequestHeader
- WithHttpRequestId
- WithHttpRequestIpAddress
- WithHttpRequestMethod
- WithHttpRequestPath
- WithHttpRequestProtocol
- WithHttpRequestQueryString
- WithHttpRequestRole
- WithHttpRequestScheme
- WithHttpRequestTradeIdentifier
- WithHttpRequestUserAgent
- WithHttpRequestUserIdentityName
