using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Magxe.Dao;
using Microsoft.EntityFrameworkCore;

namespace Magxe.IdentityServer
{
    public class InDatabasePersistedGrantStore : IPersistedGrantStore
    {
        private readonly DataContext _dbContext;

        public InDatabasePersistedGrantStore(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            var c = await _dbContext.Clients.FirstAsync(r => r.Slug == grant.ClientId);
            var u = await _dbContext.Users.FirstAsync(r => r.Email == grant.SubjectId);
            _dbContext.AccessTokens.Add(new AccessToken()
            {
                Token = grant.Key,
                Client = c,
                User = u,
                Expires = grant.Expiration ?? DateTime.Now.AddSeconds(3600),
            });

            _dbContext.SaveChanges();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            throw new System.NotImplementedException();
        }
    }
}