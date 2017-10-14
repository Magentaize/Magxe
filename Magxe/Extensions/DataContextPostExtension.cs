using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;
using static Magxe.Constants;

namespace Magxe.Extensions
{
    internal static class DataContextPostExtension
    {
        public static IEnumerable<Post> GetPagePosts(this DbSet<Post> dbSet, int pageIndex)
        {
            return dbSet.OrderByDescending(p => p.PublishedTime).Skip((pageIndex - 1) * PostPerPage).Take(PostPerPage);
        }

        public static async Task<int> GetTotalPageAsync(this DbSet<Post> dbSet)
        {
            return (await dbSet.CountAsync() + PostPerPage - 1) / PostPerPage;
        }
    }
}