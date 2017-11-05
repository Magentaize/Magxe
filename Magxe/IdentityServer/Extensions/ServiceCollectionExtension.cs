using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe.IdentityServer.Extensions
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOAuth2(this IServiceCollection services)
        {
            var builder = services.AddIdentityServer();

            builder
                .AddDeveloperSigningCredential()
                .AddPersistedGrantStore<InDatabasePersistedGrantStore>()
                .AddClientStore<InDatabasePersistedClientStore>()
                .AddInMemoryIdentityResources(new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                })
                .AddInMemoryApiResources(new List<ApiResource>())
                .Services
                .AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                .AddTransient<IProfileService, UserProfileService>()
                ;

            return services;
        }
    }
}