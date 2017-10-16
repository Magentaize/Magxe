using Magxe.Data.Setting;
using Magxe.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magxe.Extensions
{
    internal static class DataContextSettingExtension
    {
        public static async Task<BlogViewModel> GetBlogViewModelAsync(this DbSet<SettingItem> dbSet)
        {
            var vm = new BlogViewModel()
            {
                title = await dbSet.GetSettingAsync(Key.Title),
                logo = await dbSet.GetSettingAsync(Key.Logo),
                cover_image = await dbSet.GetSettingAsync(Key.CoverImage),
                description = await dbSet.GetSettingAsync(Key.Description),
                navigation = await dbSet.GetNavigationsAsync()
            };

            return vm;
        }

        public static async Task<ICollection<NavigationItem>> GetNavigationsAsync(this DbSet<SettingItem> dbSet)
        {
            ICollection<NavigationItem> re = null;
            await Task.Run(async () =>
            {
                re = JsonConvert.DeserializeObject<ICollection<NavigationItem>>(await dbSet.GetSettingAsync(Key.Navigation));
            });

            return re;
        }

        public static async Task<string> GetSettingAsync(this DbSet<SettingItem> dbSet, Key key)
        {
            var item = await dbSet.FirstOrDefaultAsync(s => s.Id == key);

            return item.Value;
        }
    }
}