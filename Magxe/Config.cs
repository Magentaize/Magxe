using System;

namespace Magxe
{
    internal static class Config
    {
        internal static Uri Url { get; set; } = new Uri("http://localhost:2365");

        internal static string AssetHash { get; set; } = null;

        internal static IServiceProvider ServiceProvider { get; set; }
    }
}