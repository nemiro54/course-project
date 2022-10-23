using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class ChangeUserModelByAddedIsBlockField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlock",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlock",
                table: "AspNetUsers");
        }
    }
}
