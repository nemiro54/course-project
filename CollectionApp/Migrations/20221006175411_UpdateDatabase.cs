using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_AspNetUsers_UserId",
                table: "CollectionItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CollectionItems",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems",
                newName: "IX_CollectionItems_userId");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "CollectionItems",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CollectionItems",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: false),
                    NameNumField1 = table.Column<string>(type: "text", nullable: false),
                    NameNumField2 = table.Column<string>(type: "text", nullable: false),
                    CollectionId = table.Column<string>(type: "text", nullable: false),
                    CollectionItemsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_CollectionItems_CollectionItemsId",
                        column: x => x.CollectionItemsId,
                        principalTable: "CollectionItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionItemsId",
                table: "Items",
                column: "CollectionItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_AspNetUsers_userId",
                table: "CollectionItems",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_AspNetUsers_userId",
                table: "CollectionItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "CollectionItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionItems_userId",
                table: "CollectionItems",
                newName: "IX_CollectionItems_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CollectionItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CollectionItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_AspNetUsers_UserId",
                table: "CollectionItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
