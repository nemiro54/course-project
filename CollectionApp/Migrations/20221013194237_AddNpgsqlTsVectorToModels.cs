using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace CollectionApp.Migrations
{
    public partial class AddNpgsqlTsVectorToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "MyCollections",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name", "Summary", "Theme" });

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Items",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name" });

            migrationBuilder.UpdateData(
                table: "XDbCultures",
                keyColumn: "ID",
                keyValue: "be",
                column: "EnglishName",
                value: "Belarusian");

            migrationBuilder.CreateIndex(
                name: "IX_MyCollections_SearchVector",
                table: "MyCollections",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SearchVector",
                table: "Items",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyCollections_SearchVector",
                table: "MyCollections");

            migrationBuilder.DropIndex(
                name: "IX_Items_SearchVector",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "MyCollections");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "XDbCultures",
                keyColumn: "ID",
                keyValue: "be",
                column: "EnglishName",
                value: "Belorussian");
        }
    }
}
