using System;
using Magxe.Dao;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe
{
    internal static class GlobalVariables
    {
        public static ConfigScheme Config { get; set; }

        public static string AssetHash { get; set; } = null;

        public static IServiceProvider ServiceProvider { get; set; }

        public static DataContext DataContext => ServiceProvider.GetService<DataContext>();
    }
}