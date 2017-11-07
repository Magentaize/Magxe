using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Magxe.IdentityServer.Extensions
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOAuth2(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
                {
                    options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, builder =>
                    {
                        builder.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme,
                            jwtBearerOptions =>
                            {
                                var filename = Path.Combine(Directory.GetCurrentDirectory(), "tempkey.rsa");
                                var keyFile = File.ReadAllText(filename);
                                var tempKey = JsonConvert.DeserializeObject<TemporaryRsaKey>(keyFile);
                                var rsa = new RsaSecurityKey(tempKey.Parameters) { KeyId = tempKey.KeyId };
                                jwtBearerOptions.TokenValidationParameters.IssuerSigningKey = rsa;
                                jwtBearerOptions.TokenValidationParameters.ValidIssuer =
                                    GlobalVariables.Config.Url.AbsoluteUri;
                            }
                    });
                })
                , null);

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