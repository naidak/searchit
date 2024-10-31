using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class izbrisaneNekeKlase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "CVJezici");

            migrationBuilder.DropTable(
                name: "CVTehnologije");

            migrationBuilder.DropTable(
                name: "CVVjestine");

            migrationBuilder.DropTable(
                name: "RadnoIskustvo");

            migrationBuilder.DropTable(
                name: "Teme");

            migrationBuilder.DropTable(
                name: "Jezici");

            migrationBuilder.DropTable(
                name: "Tehnologije");

            migrationBuilder.DropTable(
                name: "Vjestine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jezici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jezici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RadnoIskustvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NazivKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazivPozicija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnoIskustvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadnoIskustvo_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tehnologije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehnologije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vjestine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjestine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CVJezici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    JezikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVJezici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVJezici_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVJezici_Jezici_JezikId",
                        column: x => x.JezikId,
                        principalTable: "Jezici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVTehnologije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    TehnologijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVTehnologije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVTehnologije_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVTehnologije_Tehnologije_TehnologijaId",
                        column: x => x.TehnologijaId,
                        principalTable: "Tehnologije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVVjestine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    VjestinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVVjestine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVVjestine_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVVjestine_Vjestine_VjestinaId",
                        column: x => x.VjestinaId,
                        principalTable: "Vjestine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnikId",
                table: "AutentifikacijaToken",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_CVJezici_CVId",
                table: "CVJezici",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVJezici_JezikId",
                table: "CVJezici",
                column: "JezikId");

            migrationBuilder.CreateIndex(
                name: "IX_CVTehnologije_CVId",
                table: "CVTehnologije",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVTehnologije_TehnologijaId",
                table: "CVTehnologije",
                column: "TehnologijaId");

            migrationBuilder.CreateIndex(
                name: "IX_CVVjestine_CVId",
                table: "CVVjestine",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVVjestine_VjestinaId",
                table: "CVVjestine",
                column: "VjestinaId");

            migrationBuilder.CreateIndex(
                name: "IX_RadnoIskustvo_CVId",
                table: "RadnoIskustvo",
                column: "CVId");
        }
    }
}
