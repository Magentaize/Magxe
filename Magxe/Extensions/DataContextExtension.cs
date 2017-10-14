using Magxe.Data;
using Magxe.Data.Setting;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Magxe.Extensions
{
    internal static class DataContextExtension
    {
        public static async Task<string> GetSettingAsync(this DataContext dataContext, Key key)
        {
            return (await dataContext.Settings.FirstOrDefaultAsync(s => s.Id == key)).Value;
        }
    }
}