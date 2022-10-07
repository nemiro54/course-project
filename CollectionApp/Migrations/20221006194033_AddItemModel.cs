using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class AddItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionItems");

            migrationBuilder.CreateTable(
                name: "MyCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    UrlImg = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyCollections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MyCollectionId = table.Column<string>(type: "text", nullable: false),
                    MyCollectionId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_MyCollections_MyCollectionId1",
                        column: x => x.MyCollectionId1,
                        principalTable: "MyCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_MyCollectionId1",
                table: "Item",
                column: "MyCollectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_MyCollections_UserId",
                table: "MyCollections",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "MyCollections");

            migrationBuilder.CreateTable(
                name: "CollectionItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    UrlImg = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems",
                column: "UserId");
        }
    }
}
