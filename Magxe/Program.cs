using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Magxe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
            BuildWebHost(args).Run();
            AppDomain.CurrentDomain.UnhandledException += (o, e) =>
            {
                Debug.WriteLine(e);
            };
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}
