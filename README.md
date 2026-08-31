[![](https://img.shields.io/nuget/v/soenneker.paypal.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.paypal.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.paypal.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.paypal.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.paypal.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.paypal.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.paypal.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.paypal.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.PayPal.HttpClients

Provides a cached `HttpClient` configured for PayPal's REST API using an OAuth access token.

## Installation

```bash
dotnet add package Soenneker.PayPal.HttpClients
```

## Configuration

```json
{
  "PayPal": {
    "AccessToken": "your-oauth-access-token",
    "ClientBaseUrl": "https://api-m.sandbox.paypal.com"
  }
}
```

Use `https://api-m.paypal.com` for live requests; it is the default when `ClientBaseUrl` is omitted. This package does not exchange client credentials or refresh tokens. Replace the configured access token when it expires, then recreate the provider so a new client is built.

`PayPal:ApiKey` remains a compatibility fallback for `AccessToken`. `PayPal:AuthHeaderName` and `PayPal:AuthHeaderValueTemplate` can override the authorization defaults.

## Usage

```csharp
using Soenneker.PayPal.HttpClients.Abstract;
using Soenneker.PayPal.HttpClients.Registrars;

services.AddPayPalOpenApiHttpClientAsSingleton();

IPayPalOpenApiHttpClient provider = serviceProvider
    .GetRequiredService<IPayPalOpenApiHttpClient>();

HttpClient client = await provider.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync(
    "v1/invoicing/invoices?page_size=10",
    cancellationToken);
response.EnsureSuccessStatusCode();
```

The provider owns its cached client. Disposing the provider removes and disposes that client. Scoped registration gives each provider instance its own cached client.
