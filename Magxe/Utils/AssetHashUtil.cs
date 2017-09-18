using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Magxe.Utils
{
    internal static class AssetHashUtil
    {
        internal static string GenerateAssetHash()
        {
            using (var hash = MD5.Create())
            {
                var data = hash.ComputeHash(Encoding.Default.GetBytes(
                    $"{Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}{DateTime.Now.Millisecond}"));
                var sb = new StringBuilder();
                foreach (var b in data)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().Substring(0, 10).ToLower();
            }
        }
    }
}
