using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class AddCollectionItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionItems");
        }
    }
}
