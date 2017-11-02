using Microsoft.Extensions.DependencyInjection;
using System;

namespace Magxe.Extensions
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection BuildServiceProvider(this IServiceCollection services,
            out IServiceProvider provider)
        {
            provider = services.BuildServiceProvider();
            return services;
        }
    }
}