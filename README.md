

# Serilog.Plus
Contains enricher libraries for Serilog

# Serilog.Enrichers.HttpRequest
Enrich serilog events with HttpRequest information.

Install the Serilog.Enrichers.HttpRequest NuGet package
```
Install-Package Serilog.Enrichers.HttpRequest
```
OR
```
dotnet add package Serilog.Enrichers.HttpRequest
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
- WithHttpRequestTraceIdentifier
- WithHttpRequestUserAgent
- WithHttpRequestUserIdentityName

# Serilog.Enrichers.System
Enrich serilog events with system information.

Install the Serilog.Enrichers.System NuGet package
```
Install-Package Serilog.Enrichers.System
```
OR
```
dotnet add package Serilog.Enrichers.System
```
## System Enricher Methods

- WithEnvironmentVariable
- WithHostIpAddress
- WithMacAddress
- WithMachineName
- WithOSVersion
- WithStackTrace
- WithThreadId
- WithTimeZone
