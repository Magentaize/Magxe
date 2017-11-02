using IdentityServer4.Models;
using IdentityServer4.Stores;
using Magxe.Dao;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Client = IdentityServer4.Models.Client;

namespace Magxe.IdentityServer
{
    public class InDatabasePersistedClientStore : IClientStore
    {
        private readonly DataContext _dbContext;

        public InDatabasePersistedClientStore(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var cr = _dbContext.Clients.FirstOrDefault(r => r.Slug.Equals(clientId));
            if (cr == null)
            {
                return Task.FromResult<Client>(null);
            }
            return Task.FromResult<Client>(new Client()
            {
                ClientId = cr.Slug,
                ClientName = cr.Name,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret(cr.Secret.Sha256())
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AllowOfflineAccess = true
            });
        }
    }
}