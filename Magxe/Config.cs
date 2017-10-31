using Magxe.Dao;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Magxe
{
    public static class Config
    {
        public static Uri Url { get; set; } = new Uri("http://localhost:2365");

        internal static string AssetHash { get; set; } = null;

        internal static IServiceProvider ServiceProvider { get; set; }

        internal static DataContext DataContext => ServiceProvider.GetService<DataContext>();
    }
}