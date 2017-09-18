using HandlebarsDotNet;
using Magxe.Data.Meta;

namespace Magxe.Helpers
{
    internal static class AssetHelper
    {
        internal static void RegisterHelper()
        {
            Handlebars.RegisterHelper("asset", (writer, context, parameters) =>
            {
                writer.WriteSafeString(AssetUrl.GetAssetUrl((string) parameters[0]));
            });
        }
    }
}