using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Magxe.Data.Setting
{
    public static class SettingExtension
    {
        public static async Task<ICollection<NavigationItem>> GetNavigationsAsync(this DbSet<SettingItem> dbSet)
        {
            ICollection<NavigationItem> re = null;
            await Task.Run(async () =>
            {
                re = JsonConvert.DeserializeObject<ICollection<NavigationItem>>(await dbSet.GetValueAsync(Key.Navigation));
            });

            return re;
        }

        public static async Task<BlogModel> GetBlogModelAsync(this DbSet<SettingItem> db)
        {
            BlogModel model = null;
            await Task.Run(async () =>
            {
                model = new BlogModel()
                {
                    title = await db.GetValueAsync(Key.Title),
                    logo = await db.GetValueAsync(Key.Logo),
                    navigation = await db.GetNavigationsAsync(),
                    url = await db.GetValueAsync(Key.Url)
                };
            });

            return model;
        }

        private static async Task<string> GetValueAsync(this DbSet<SettingItem> db, Key key)
        {
            return (await db.FirstOrDefaultAsync(s => s.Id == key)).Value;
        }
    }
}