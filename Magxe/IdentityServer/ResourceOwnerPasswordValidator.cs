using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Magxe.Dao;
using Magxe.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Magxe.IdentityServer
{
    internal class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly DataContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly UserRepository _userRepo;

        public ResourceOwnerPasswordValidator(UserRepository userRepo, DataContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _userRepo = userRepo;
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _userRepo.FirstById();
            context.Result = new GrantValidationResult(subject: context.UserName,
                authenticationMethod: "Id", claims: new[] {new Claim(ClaimTypes.Sid, context.UserName)});

            return Task.CompletedTask;
        }
    }
}