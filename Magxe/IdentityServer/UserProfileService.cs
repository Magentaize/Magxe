using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Magxe.Dao;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Magxe.IdentityServer
{
    public class UserProfileService : IProfileService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<User> _logger;

        public UserProfileService(DataContext dataContext, ILogger<User> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.LogProfileRequest(_logger);
            context.AddRequestedClaims(context.Subject.Claims);
            context.LogIssuedClaims(_logger);

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var email = context.Subject.GetSubjectId();
            context.IsActive = _dataContext.Users.FirstOrDefault(r => r.Email == email)?.Status == UserStatus.Active;

            return Task.CompletedTask;
        }
    }
}