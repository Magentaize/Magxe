using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Magxe.Dao;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RefreshToken = IdentityServer4.Models.RefreshToken;

namespace Magxe.IdentityServer
{
    internal class InDatabaseRefreshTokenStore : IRefreshTokenStore
    {
        private readonly DataContext _dbContext;
        private readonly IHandleGenerationService _handleGenerationService;

        public InDatabaseRefreshTokenStore(DataContext dbContext, IHandleGenerationService handleGenerationService)
        {
            _dbContext = dbContext;
            _handleGenerationService = handleGenerationService;
        }

        public async Task<string> StoreRefreshTokenAsync(RefreshToken refreshToken)
        {
            var handle = await _handleGenerationService.GenerateAsync();
            var token =  GetHashedKey(handle);

            var c = await _dbContext.Clients.FirstAsync(r => r.Slug == refreshToken.ClientId);
            var u = await _dbContext.Users.FirstAsync(r => r.Email == refreshToken.SubjectId);
            _dbContext.RefreshTokens.Add(new Dao.RefreshToken()
            {
                Token = token,
                Client = c,
                User = u,
                //Expires = refreshToken.Lifetime ?? DateTime.Now.AddSeconds(3600),
            });

            _dbContext.SaveChanges();

            return handle;
        }

        public Task UpdateRefreshTokenAsync(string handle, RefreshToken refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<RefreshToken> GetRefreshTokenAsync(string refreshTokenHandle)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveRefreshTokenAsync(string refreshTokenHandle)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveRefreshTokensAsync(string subjectId, string clientId)
        {
            throw new System.NotImplementedException();
        }

        private const string KeySeparator = ":";

        private const string GrantType = "refresh_token";

        private string GetHashedKey(string value)
        {
            return (value + KeySeparator + GrantType).Sha256();
        }
    }
}