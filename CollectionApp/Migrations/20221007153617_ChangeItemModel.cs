using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class ChangeItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_MyCollections_MyCollectionId1",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_MyCollectionId1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "MyCollectionId1",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "MyCollectionId",
                table: "Items",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MyCollectionId",
                table: "Items",
                column: "MyCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_MyCollections_MyCollectionId",
                table: "Items",
                column: "MyCollectionId",
                principalTable: "MyCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_MyCollections_MyCollectionId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MyCollectionId",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "MyCollectionId",
                table: "Item",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "MyCollectionId1",
                table: "Item",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_MyCollectionId1",
                table: "Item",
                column: "MyCollectionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_MyCollections_MyCollectionId1",
                table: "Item",
                column: "MyCollectionId1",
                principalTable: "MyCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
