using System.Linq;
using Magxe.Dao;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Repositories
{
    internal class UserRepository : BaseRepository
    {
        public DbSet<User> Users => DbContext.Users;

        public IQueryable<User> FirstById()
        {
            return null;
        }

        public User FirstByEmail(string email)
        {
            var u = Users.First(r => r.Email == email);
            //u.Roles = DbContext.UserRoles.Include(r => r.UserId == u.Id).Where(r =>true);
            return null;
        }
    }
}