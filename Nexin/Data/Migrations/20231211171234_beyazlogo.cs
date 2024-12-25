using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class beyazlogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeyazLogo",
                table: "LayoutAyars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeyazLogo",
                table: "LayoutAyars");
        }
    }
}
