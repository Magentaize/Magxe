using System.Text.RegularExpressions;

namespace Magxe.Utils
{
    internal static class UrlUtil
    {
        internal static string GetSubDir()
        {
            var localPath = string.Empty;
            if (GlobalVariables.Config.Url != null)
            {
                localPath = GlobalVariables.Config.Url.AbsolutePath;
                if (localPath != "/")
                {
                    localPath = Regex.Replace(localPath, @"\/$", string.Empty);
                }
            }

            return (localPath == "/") ? string.Empty : localPath;
        }
    }
}