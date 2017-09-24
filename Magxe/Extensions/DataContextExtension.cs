using System.Threading.Tasks;
using Magxe.Data;
using Magxe.Data.Setting;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Extensions
{
    internal static class DataContextExtension
    {
        public static async Task<string> GetValueAsync(this DataContext dataContext, Key key)
        {
            return (await dataContext.Settings.FirstOrDefaultAsync(s => s.Id == key)).Value;
        }
    }
}