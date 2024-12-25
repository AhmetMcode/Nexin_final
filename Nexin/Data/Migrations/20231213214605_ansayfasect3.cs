using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class ansayfasect3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaSayfaSeciton3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltYazi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimSol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimOynar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaSayfaSeciton3", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaSayfaSeciton3");
        }
    }
}
