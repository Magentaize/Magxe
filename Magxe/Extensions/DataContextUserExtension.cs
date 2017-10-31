using Magxe.Dao;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Magxe.Extensions
{
    internal static class DataContextUserExtension
    {
        public static async Task<User> GetUserByIdAsync(this DbSet<User> dbSet, string id)
        {
            var user = await dbSet.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}