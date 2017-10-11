using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Data;
using Magxe.Data.Setting;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Extensions
{
    internal static class DataContextExtension
    {
        public static async Task<string> GetSettingAsync(this DataContext dataContext, Key key)
        {
            return (await dataContext.Settings.FirstOrDefaultAsync(s => s.Id == key)).Value;
        }

        public static async Task<IList<Post>> GetPostsAsync(this DataContext dataContext, int page)
        {
            return await dataContext.Posts.OrderByDescending(k => k.Id).Take(5).ToListAsync();
        }

        public static async Task<IList<Tag>> GetTagsAsync(this DataContext dataContext, int[] tagIds)
        {
            return await dataContext.Tags.Where(t => tagIds.Contains(t.Id)).ToListAsync();
        }
    }
}