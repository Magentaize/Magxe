using System;
using Magxe.Dao.Enum;
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
            SeedPosts(builder);
        }

        public static void SeedPosts(MigrationBuilder builder)
        {
            builder.InsertData(
                "Users",
                new[] { "Id", "Name", "Slug" ,"CreatedTime", "Email","LastSeen","Password","Status"},
                new object[,] { { "1", "Magxe", "magentaize", DateTime.Now, "magxe@example.com" ,DateTime.Now,Guid.NewGuid().ToString("N"),(int)UserStatus.InActive} }
            );

            var postsValue = new object[10, 9];
            for (int i = 0; i <= 9; i++)
            {
                postsValue[i, 0] = 1;
                postsValue[i, 1] = DateTime.Now;
                postsValue[i, 2] =
                    "<div class=\"kg-card-markdown\"><p>Hey! Welcome to Ghost, it's great to have you :)</p><p>We know that first impressions are important, so we've populated your new site with some initial <strong>Getting Started</strong> posts that will help you get familiar with everything in no time. This is the first one!</p><h3 id=\"thereareafewthingsthatyoushouldknowupfront\">There are a few things that you should know up-front:</h3><ol><li><p>Ghost is designed for ambitious, professional publishers who want to actively build a business around their content. That's who it works best for. If you're using Ghost for some other purpose, that's fine too - but it might not be the best choice for you.</p></li><li><p>The entire platform can be modified and customized to suit your needs, which is very powerful, but doing so <strong>does</strong> require some knowledge of code. Ghost is not necessarily a good platform for beginners or people who just want a simple personal blog.</p></li><li><p>For the best experience we recommend downloading the <a href=\"https://ghost.org/downloads/\">Ghost Desktop App</a> for your computer, which is the best way to access your Ghost site on a desktop device.</p></li></ol><p>Ghost is made by an independent non-profit organisation called the Ghost Foundation. We are 100% self funded by revenue from our <a href=\"https://ghost.org/pricing\">Ghost(Pro)</a> service, and every penny we make is re-invested into funding further development of free, open source technology for modern journalism.</p><p>The main thing you'll want to read about next is probably: <a href=\"/the-editor/\">the Ghost editor</a>.</p><p>Once you're done reading, you can simply delete the default <strong>Ghost</strong> user from your team to remove all of these introductory posts!</p></div>";
                postsValue[i, 3] = @"Hey! Welcome to Ghost, it's great to have you :)
We know that first impressions are important, so we've populated your new site
with some initial Getting Started  posts that will help you get familiar with
everything in no time. This is the first one!
There are a few things that you should know up-front:
 1. Ghost is designed for ambitious, professional publishers who want to
    actively build a business around their content. That's who it works best
    for. If you're using Ghost for some other purpose, that's fine too - but it
    might not be the best choice for you.
    
    
 2. The entire platform can be modified and customized to suit your needs, which
    is very powerful, but doing so does  require some knowledge of code. Ghost
    is not necessarily a good platform for beginners or people who just want a
    simple personal blog.
    
    
 3. For the best experience we recommend downloading the Ghost Desktop App
    [https://ghost.org/downloads/]  for your computer, which is the best way to
    access your Ghost site on a desktop device.
    
    
Ghost is made by an independent non-profit organisation called the Ghost
Foundation. We are 100% self funded by revenue from our Ghost(Pro)
[https://ghost.org/pricing]  service, and every penny we make is re-invested
into funding further development of free, open source technology for modern
journalism.
The main thing you'll want to read about next is probably: the Ghost editor
[/the-editor/].
Once you're done reading, you can simply delete the default Ghost  user from
your team to remove all of these introductory posts!";
                postsValue[i, 4] = DateTime.Now;
                postsValue[i, 5] = $"welcome{i}";
                postsValue[i, 6] = "Welcome to Ghost";
                postsValue[i, 7] = DateTime.Now;
                postsValue[i, 8] = (int)PostStatus.Published;
            }
            builder.InsertData(
                "Posts",
                new[] { "AuthorId", "CreatedTime", "Html", "PlainText", "PublishedTime", "Slug", "Title", "UpdatedTime", "Status"},
                postsValue
            );

            var tagsValue = new object[3, 2];
            for (int i = 0; i < 3; i++)
            {
                tagsValue[i, 0] = $"tag{i}";
                tagsValue[i, 1] = $"Tag {i}";
            }
            builder.InsertData(
                "Tags",
                new[] { "Slug", "Name" },
                tagsValue
            );

            var postTagsValue = new object[7, 2];
            for (int i = 0; i <= 6; i++)
            {
                postTagsValue[i, 0] = i + 4;
                postTagsValue[i, 1] = 2;
            }
            builder.InsertData(
                "Posts_Tags",
                new[] { "PostId", "TagId" },
                postTagsValue
            );
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
            var es = System.Enum.GetValues(typeof(Key));
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