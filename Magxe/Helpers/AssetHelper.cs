using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data.Meta;
using Magxe.Extensions;

namespace Magxe.Helpers
{
    internal class AssetHelper : BaseHelper
    {
        public AssetHelper():base("asset", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            output.WriteSafeString(AssetUrl.GetAssetUrl(arguments[0].Cast<string>()));
        }
    }
}