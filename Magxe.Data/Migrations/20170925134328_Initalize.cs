using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Magxe.Data.Migrations
{
    public partial class Initalize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CodeInjectionFoot = table.Column<string>(type: "longtext", nullable: true),
                    CodeInjectionHead = table.Column<string>(type: "longtext", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomExcerpt = table.Column<string>(type: "text", nullable: true),
                    FeatureImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Html = table.Column<string>(type: "longtext", nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "varchar(50)", nullable: true),
                    MobileDoc = table.Column<string>(type: "longtext", nullable: true),
                    PlainText = table.Column<string>(type: "longtext", nullable: true),
                    PublishedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Slug = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FeatureImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Slug = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    CoverImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastLog = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ProfileImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Slug = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            var es = Enum.GetValues(typeof(Setting.Key));
            var settingsValue = new object[es.Length, 3];
            for (int i = 0; i < es.Length; i++)
            {
                var e = (Setting.Key) i;
                settingsValue[i, 0] = i;
                settingsValue[i, 1] = e.ToString();
                string value;
                switch (e)
                {
                    case Setting.Key.DisplayUpdateNotification:
                        value = "1.0";
                        break;
                    case Setting.Key.Title:
                        value = "Magxe";
                        break;
                    case Setting.Key.Description:
                        value = "Title of Magxe";
                        break;
                    case Setting.Key.TimeZone:
                        value = "Asia/Shanghai";
                        break;
                    case Setting.Key.Theme:
                        value = "casperv1";
                        break;
                    case Setting.Key.Navigation:
                        value =
                            "[{\"label\":\"Home\", \"url\":\"/\"},{\"label\":\"Home2\", \"url\":\"/wwwww\"},{\"label\":\"Home3\", \"url\":\"/wwwww\"}]";
                        break;
                    default:
                        value = string.Empty;
                        break;
                }
                settingsValue[i, 2] = value;
            }

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] {"Id", "Name", "Value"},
                values: settingsValue
            );

            var postsValue = new object[4, 8];
            for (int i = 0; i < 4; i++)
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
            }
            migrationBuilder.InsertData(
                "Posts",
                new[] {"AuthorId", "CreatedTime", "Html", "PlainText", "PublishedTime", "Slug", "Title", "UpdatedTime"},
                postsValue
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
