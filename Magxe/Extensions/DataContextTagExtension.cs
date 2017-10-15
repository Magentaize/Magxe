using System.Collections.Generic;
using System.Linq;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Extensions
{
    internal static class DataContextTagExtension
    {
        public static IEnumerable<Tag> GetTagsByIds(this DbSet<Tag> dbSet, IEnumerable<int> tagIds)
        {
            return dbSet.Where(t => tagIds.Contains(t.Id));
        }
    }
}