using Magxe.Dao;
using Magxe.Repositories.Abstractions;

namespace Magxe.Repositories
{
    internal class RefreshTokenRepository : ITokenRepository
    {
        private readonly DataContext _dbContext;

        public RefreshTokenRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}