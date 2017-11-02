using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Magxe.Migrations
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
                    AuthorId = table.Column<string>(type: "longtext", nullable: true),
                    CodeInjectionFoot = table.Column<string>(type: "longtext", nullable: true),
                    CodeInjectionHead = table.Column<string>(type: "longtext", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomExcerpt = table.Column<string>(type: "text", nullable: true),
                    FeatureImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Html = table.Column<string>(type: "longtext", nullable: true),
                    IsPage = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(127)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "text", maxLength: 2000, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                    Id = table.Column<string>(type: "varchar(127)", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    CoverImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    LastLog = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ProfileImage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Slug = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles_Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(127)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Claims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(127)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Claims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Logins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(127)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(127)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(127)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Logins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Users_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Roles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(127)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(127)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Users_Roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Tokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(127)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(127)", nullable: false),
                    Name = table.Column<string>(type: "varchar(127)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Tokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Users_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "roles_name_unique",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Claims_RoleId",
                table: "Roles_Claims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "users_email_unique",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_slug_unique",
                table: "Users",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Claims_UserId",
                table: "Users_Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Logins_UserId",
                table: "Users_Logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_RoleId",
                table: "Users_Roles",
                column: "RoleId");

            var es = Enum.GetValues(typeof(Dao.Setting.Key));
            var settingsValue = new object[es.Length, 3];
            for (int i = 0; i < es.Length; i++)
            {
                var e = (Dao.Setting.Key)i;
                settingsValue[i, 0] = i;
                settingsValue[i, 1] = e.ToString();
                string value;
                switch (e)
                {
                    case Dao.Setting.Key.DisplayUpdateNotification:
                        value = "1.0";
                        break;
                    case Dao.Setting.Key.Title:
                        value = "Magxe";
                        break;
                    case Dao.Setting.Key.Description:
                        value = "Title of Magxe";
                        break;
                    case Dao.Setting.Key.TimeZone:
                        value = "Asia/Shanghai";
                        break;
                    case Dao.Setting.Key.Theme:
                        value = "casperv1";
                        break;
                    case Dao.Setting.Key.Navigation:
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
                columns: new[] { "Id", "Name", "Value" },
                values: settingsValue
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Roles_Claims");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Users_Claims");

            migrationBuilder.DropTable(
                name: "Users_Logins");

            migrationBuilder.DropTable(
                name: "Users_Roles");

            migrationBuilder.DropTable(
                name: "Users_Tokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
