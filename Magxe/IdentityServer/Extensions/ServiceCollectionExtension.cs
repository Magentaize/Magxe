using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Magxe.IdentityServer.Extensions
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOAuth2(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var filename = Path.Combine(Directory.GetCurrentDirectory(), "tempkey.rsa");
                    var keyFile = File.ReadAllText(filename);
                    var tempKey = JsonConvert.DeserializeObject<TemporaryRsaKey>(keyFile);
                    var rsa = new RsaSecurityKey(tempKey.Parameters) {KeyId = tempKey.KeyId};

                    options.SaveToken = true;
                    options.RefreshOnIssuerKeyNotFound = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuers = new[]
                            {GlobalVariables.Config.Url.OriginalString, GlobalVariables.Config.Url.AbsoluteUri},
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,
                        IssuerSigningKey = rsa,
                    };
                });

            services.AddIdentityServer()
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