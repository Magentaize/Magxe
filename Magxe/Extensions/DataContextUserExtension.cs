using System.Threading.Tasks;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Extensions
{
    internal static class DataContextUserExtension
    {
        public static async Task<User> GetUserByIdAsync(this DbSet<User> dbSet, int id)
        {
            return await dbSet.FirstAsync(u => u.Id == id);
        }
    }
}