using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Magxe.Dao;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Magxe.IdentityServer
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOAuth2(this IServiceCollection services)
        {
            var builder = services.AddIdentityServer();

            builder
                .AddDeveloperSigningCredential()
                .AddInMemoryPersistedGrants()
                .AddClientStore<InDatabasePersistedClientStore>()
                .AddInMemoryIdentityResources(new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                })
                .AddInMemoryApiResources(new List<ApiResource>())
                .Services
                .AddTransient<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                .AddTransient<IProfileService, UserProfileService>()
                ;

            return services;
        }
    }
}