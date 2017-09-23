using System;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe.Extensions
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection BuildServiceProvider(this IServiceCollection services,
            out IServiceProvider provider)
        {
            provider = services.BuildServiceProvider();
            return services;
        }
    }
}