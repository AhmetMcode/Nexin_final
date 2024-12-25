using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexin.Data.Migrations
{
    public partial class hakkimizdaanasayfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HakkimizdaAnaSayfa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazi1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazi2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazi3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazi4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazi5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HakkimizdaAnaSayfa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hizmet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KapakResimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnaResim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnaResim1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnaResim2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ilkYazi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ikinciYazi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik8 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HakkimizdaAnaSayfa");

            migrationBuilder.DropTable(
                name: "Hizmet");
        }
    }
}
