using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;

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

        public static IWebHost BuildWebHost(string[] args)
        {
            var cfgm = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText("magxe.config.json"),new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            GlobalVariables.Config = cfgm.IsDevelopment ? cfgm.Development : cfgm.Production;
            GlobalVariables.Config.ConnectionString = new MySqlConnectionStringBuilder()
            {
                Server = GlobalVariables.Config.Database.Connection.Host,
                Port = (uint) GlobalVariables.Config.Database.Connection.Port,
                UserID = GlobalVariables.Config.Database.Connection.User,
                Password = GlobalVariables.Config.Database.Connection.Password,
                Database = GlobalVariables.Config.Database.Connection.Database,
                ConvertZeroDateTime = true,
            }.ConnectionString;

            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var env = builderContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .UseUrls(GlobalVariables.Config.Url.AbsoluteUri)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
