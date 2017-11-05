using IdentityServer4.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe.IdentityServer.Extensions
{
    internal static class IdentityServerBuilderExtension
    {
        public static IIdentityServerBuilder AddPersistedGrantStore<T>(this IIdentityServerBuilder builder)
            where T : class, IPersistedGrantStore
        {
            builder.Services.AddTransient<IPersistedGrantStore, T>();

            return builder;
        }
    }
}