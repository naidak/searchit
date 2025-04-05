using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class PorukeKorisnici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PorukeKorisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PorukaId = table.Column<int>(type: "int", nullable: false),
                    isPrimljena = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorukeKorisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PorukeKorisnici_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PorukeKorisnici_Poruke_PorukaId",
                        column: x => x.PorukaId,
                        principalTable: "Poruke",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PorukeKorisnici_KorisnikId",
                table: "PorukeKorisnici",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_PorukeKorisnici_PorukaId",
                table: "PorukeKorisnici",
                column: "PorukaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PorukeKorisnici");
        }
    }
}
