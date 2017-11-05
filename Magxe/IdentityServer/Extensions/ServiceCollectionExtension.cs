using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe.IdentityServer.Extensions
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOAuth2(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddPersistedGrantStore<InDatabasePersistedGrantStore>()
                //.AddRefreshTokenStore<InDatabaseRefreshTokenStore>()
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