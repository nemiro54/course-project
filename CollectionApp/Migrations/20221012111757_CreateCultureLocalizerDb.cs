using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class CreateCultureLocalizerDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XDbCultures",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XDbCultures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "XDbResources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CultureID = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XDbResources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_XDbResources_XDbCultures_CultureID",
                        column: x => x.CultureID,
                        principalTable: "XDbCultures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "XDbCultures",
                columns: new[] { "ID", "EnglishName", "IsActive", "IsDefault" },
                values: new object[,]
                {
                    { "be", "Belorussian", true, false },
                    { "en", "English", true, true },
                    { "pl", "Polish", true, false }
                });

            migrationBuilder.InsertData(
                table: "XDbResources",
                columns: new[] { "ID", "Comment", "CultureID", "IsActive", "Key", "Value" },
                values: new object[] { 1, "Created by XLocalizer", "be", true, "Welcome", "Вітаем" });

            migrationBuilder.CreateIndex(
                name: "IX_XDbResources_CultureID_Key",
                table: "XDbResources",
                columns: new[] { "CultureID", "Key" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XDbResources");

            migrationBuilder.DropTable(
                name: "XDbCultures");
        }
    }
}
