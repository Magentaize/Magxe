using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Magxe.Dao;
using Microsoft.AspNetCore.Identity;

namespace Magxe.IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly DataContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ResourceOwnerPasswordValidator(DataContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            context.Result = new GrantValidationResult(subject: context.UserName,
                authenticationMethod: "Email", claims: new[] {new Claim(ClaimTypes.Email, context.UserName)});

            return Task.CompletedTask;
        }
    }
}