using Magxe.Dao.Setting;
using Magxe.Utils;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Magxe.IdentityServer
{
    internal static class SeedData
    {
        public static void SeedClients(MigrationBuilder builder)
        {
            var clients = new[,]
            {
                {"Ghost Admin", "d72bd484-af5f-46c0-8b0a-a9bc4943f141"},
                {"Ghost Frontend", "7d6afc6e-ff56-402b-9889-7d5a9542d3ce"},
                {"Ghost Scheduler", "3a7ceafa-bd95-4c05-a4fe-b54f13675d17"},
                {"Ghost Backup", "43e16bee-a378-4c66-9092-03ed538085ca"}
            };
            var clientsO = new object[4,5];
            for (var i = 0; i < 4; i++)
            {
                clientsO[i, 0] = Guid.NewGuid().ToString("N");
                clientsO[i, 1] = clients[i, 0];
                clientsO[i, 2] = clients[i, 1];
                clientsO[i, 3] = Guid.NewGuid().ToString("N");
                clientsO[i, 4] = Slug.Slugify(clients[i, 0]);
            }
            builder.InsertData(
                "Clients",
                new[] {"Id", "Name", "Uuid", "Secret", "Slug"},
                clientsO
            );
        }

        public static void SeedSettings(MigrationBuilder builder)
        {
            var es = Enum.GetValues(typeof(Key));
            var settingsValue = new object[es.Length, 3];
            for (int i = 0; i < es.Length; i++)
            {
                var e = (Key)i;
                settingsValue[i, 0] = i;
                settingsValue[i, 1] = e.ToString();
                string value;
                switch (e)
                {
                    case Key.DisplayUpdateNotification:
                        value = "1.0";
                        break;
                    case Key.Title:
                        value = "Magxe";
                        break;
                    case Key.Description:
                        value = "Title of Magxe";
                        break;
                    case Key.TimeZone:
                        value = "Asia/Shanghai";
                        break;
                    case Key.Theme:
                        value = "casperv1";
                        break;
                    case Key.Navigation:
                        value =
                            "[{\"label\":\"Home\", \"url\":\"/\"},{\"label\":\"Home2\", \"url\":\"/wwwww\"},{\"label\":\"Home3\", \"url\":\"/wwwww\"}]";
                        break;
                    default:
                        value = string.Empty;
                        break;
                }
                settingsValue[i, 2] = value;
            }

            builder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: settingsValue
            );
        }
    }
}