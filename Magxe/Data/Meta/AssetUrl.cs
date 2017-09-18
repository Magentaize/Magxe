using System.Text;
using System.Text.RegularExpressions;
using Magxe.Utils;

namespace Magxe.Data.Meta
{
    internal static class AssetUrl
    {
        internal static string GetAssetUrl(string path)
        {
            // CASE: Build the output URL
            // Add subdirectory...
            var output = new StringBuilder(UrlUtil.GetSubDir()).Append('/');

            // Optionally add /assets/
            if (!Regex.Match(path, "^public").Success && !Regex.Match(path, "^asset").Success)
            {
                output.Append("assets/");
            }

            // Add the path for the requested asset
            output.Append(path);

            // Ensure we have an assetHash
            if (Config.AssetHash == null)
                Config.AssetHash = AssetHashUtil.GenerateAssetHash();

            // Finally add the asset hash to the output URL
            output.Append($"?v={Config.AssetHash}");

            return output.ToString();
        }
    }
}