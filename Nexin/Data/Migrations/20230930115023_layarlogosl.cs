using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class layarlogosl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceLink",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedLink",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceLink",
                table: "LayoutAyars");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "LayoutAyars");

            migrationBuilder.DropColumn(
                name: "LinkedLink",
                table: "LayoutAyars");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "LayoutAyars");

            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "LayoutAyars");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "LayoutAyars");
        }
    }
}
