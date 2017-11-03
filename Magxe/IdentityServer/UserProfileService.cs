using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Magxe.Dao;
using Microsoft.EntityFrameworkCore;

namespace Magxe.IdentityServer
{
    public class UserProfileService : IProfileService
    {
        private readonly DataContext _dataContext;

        public UserProfileService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var email = context.Subject.GetSubjectId();
            context.IsActive = _dataContext.Users.FirstOrDefault(r => r.Email == email)?.Status == UserStatus.Active;

            return Task.CompletedTask;
        }
    }
}