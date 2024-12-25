using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class projeerrrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icerik1",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik2",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik3",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik4",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik5",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik6",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik7",
                table: "Hizmet");

            migrationBuilder.DropColumn(
                name: "Icerik8",
                table: "Hizmet");

            migrationBuilder.RenameColumn(
                name: "ilkYazi",
                table: "Hizmet",
                newName: "MetaTaglar");

            migrationBuilder.RenameColumn(
                name: "ikinciYazi",
                table: "Hizmet",
                newName: "Icerik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaTaglar",
                table: "Hizmet",
                newName: "ilkYazi");

            migrationBuilder.RenameColumn(
                name: "Icerik",
                table: "Hizmet",
                newName: "ikinciYazi");

            migrationBuilder.AddColumn<string>(
                name: "Icerik1",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik2",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik3",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik4",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik5",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik6",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik7",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icerik8",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
