using Microsoft.Extensions.DependencyInjection;
using System;
using Magxe.Services;

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

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ThemeService, ThemeService>();

            return services;
        }
    }
}