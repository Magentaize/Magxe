using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Magxe.Data.Migrations
{
    public partial class Initalize : Migration
    {
        protected override void Up(MigrationBuilder @this)
        {
            @this.CreateTable(
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
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            @this.CreateTable(
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

            @this.CreateTable(
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

            @this.CreateTable(
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
            var settingsValues = new object[es.Length, 3];
            for (int i = 0; i < es.Length; i++)
            {
                var e = (Setting.Key) i;
                settingsValues[i, 0] = i;
                settingsValues[i, 1] = e.ToString();
                string t;
                switch (e)
                {
                    case Setting.Key.DisplayUpdateNotification:
                        t = "1.0";
                        break;
                    case Setting.Key.Title:
                        t = "Magxe";
                        break;
                    case Setting.Key.Description:
                        t = "Title of Magxe";
                        break;
                    case Setting.Key.TimeZone:
                        t = "Asia/Shanghai";
                        break;
                    case Setting.Key.Theme:
                        t = "casperv1";
                        break;
                    default:
                        t = string.Empty;
                        break;
                }
                settingsValues[i, 2] = t;
            }

            @this.InsertData(
                table: "Settings",
                columns: new[] {"Id", "Name", "Value"},
                values: settingsValues
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
