using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.PayPal.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.PayPal.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class PayPalOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="PayPalOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPayPalOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IPayPalOpenApiHttpClient, PayPalOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PayPalOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPayPalOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IPayPalOpenApiHttpClient, PayPalOpenApiHttpClient>();

        return services;
    }
}
