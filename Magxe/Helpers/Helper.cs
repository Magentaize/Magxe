using System.Linq;
using System.Reflection;

namespace Magxe.Helpers
{
    internal static class Helper
    {
        internal static void RegisterHelpers()
        {
            AssetHelper.RegisterHelper();
            BlockAndContentForHelper.RegisterHelper();
            DateHelper.RegisterHelper();
        }
    }
}