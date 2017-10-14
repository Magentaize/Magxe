using System.Collections.Generic;
using System.Linq;
using Magxe.Data;

namespace Magxe.Extensions
{
    internal static class DataContextTagExtension
    {
        public static IEnumerable<Tag> GetTagsByIds(this DataContext dataContext, IEnumerable<int> tagIds)
        {
            return dataContext.Tags.Where(t => tagIds.Contains(t.Id));
        }
    }
}