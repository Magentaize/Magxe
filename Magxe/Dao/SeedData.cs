using System;
using Magxe.Dao.Setting;
using Magxe.Utils;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Magxe.Dao
{
    internal static class SeedData
    {
        public static void Seed(MigrationBuilder builder)
        {
            SeedClients(builder);
            SeedSettings(builder);
            SeedRoles(builder);
        }

        public static void SeedClients(MigrationBuilder builder)
        {
            var clients = new[,]
            {
                {"Ghost Admin", "d72bd484-af5f-46c0-8b0a-a9bc4943f141"},
                {"Ghost Frontend", "7d6afc6e-ff56-402b-9889-7d5a9542d3ce"},
                {"Ghost Scheduler", "3a7ceafa-bd95-4c05-a4fe-b54f13675d17"},
                {"Ghost Backup", "43e16bee-a378-4c66-9092-03ed538085ca"}
            };
            var clientsO = new object[4, 5];
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
            var settingsValue = new object[es.Length, 4];
            for (int i = 0; i < es.Length; i++)
            {
                var e = (Key) i;
                settingsValue[i, 0] = i;
                settingsValue[i, 1] = e.ToString();
                string value;
                string type_value;
                switch (e)
                {
                    case Key.DisplayUpdateNotification:
                        value = "1.0";
                        type_value = "core";
                        break;
                    case Key.Title:
                        value = "Magxe";
                        type_value = "blog";
                        break;
                    case Key.Description:
                        value = "Title of Magxe";
                        type_value = "blog";
                        break;
                    case Key.TimeZone:
                        value = "Asia/Shanghai";
                        type_value = "blog";
                        break;
                    case Key.Theme:
                        value = "casperv1";
                        type_value = "blog";
                        break;
                    case Key.Navigation:
                        value =
                            "[{\"label\":\"Home\", \"url\":\"/\"},{\"label\":\"Home2\", \"url\":\"/wwwww\"},{\"label\":\"Home3\", \"url\":\"/wwwww\"}]";
                        type_value = "blog";
                        break;
                    case Key.IsPrivate:
                        value = "false";
                        type_value = "private";
                        break;
                    case Key.Password:
                        value = string.Empty;
                        type_value = "private";
                        break;
                    default:
                        value = string.Empty;
                        type_value = "blog";
                        break;
                }
                settingsValue[i, 2] = value;
                settingsValue[i, 3] = type_value;
            }

            builder.InsertData(
                table: "Settings",
                columns: new[] {"Id", "Name", "Value", "Type"},
                values: settingsValue
            );
        }

        public static void SeedRoles(MigrationBuilder builder)
        {
            var roles = new [,]
            {
                {"Administrator","Administrators" },
                {"Editor","Editors" },
                {"Author","Authors" },
                {"Owner","Blog Owner" }
            };
            var rolesO = new object[4,3];
            for (int i = 0; i < 4; i++)
            {
                rolesO[i,0] = Guid.NewGuid().ToString("N");
                rolesO[i, 1] = roles[i, 0];
                rolesO[i, 2] = roles[i, 1];
            }

            builder.InsertData(
                "Roles",
                new[] {"Id", "Name", "Description"},
                rolesO
            );
        }
    }
}