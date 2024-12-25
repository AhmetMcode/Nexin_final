using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class projelerss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Hizmet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Hizmet");
        }
    }
}
