using System.Collections.Generic;
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
                var r = await dbSet.FirstOrDefaultAsync(s => s.Id == Key.Navigation);
                re = JsonConvert.DeserializeObject<ICollection<NavigationItem>>(
                    (await dbSet.FirstOrDefaultAsync(s => s.Id == Key.Navigation)).Value);
            });

            return re;
        }
    }
}