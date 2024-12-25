using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class ajsdlkjasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaSayfaTamamlanmis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yazisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ic1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sayi1 = table.Column<int>(type: "int", nullable: false),
                    ic2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sayi2 = table.Column<int>(type: "int", nullable: false),
                    ic3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sayi3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaSayfaTamamlanmis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaSayfaTamamlanmis");
        }
    }
}
