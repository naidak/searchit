using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class noveKlaseZaCV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edukacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivSkole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPocetka = table.Column<DateOnly>(type: "date", nullable: true),
                    DatumZavrsetka = table.Column<DateOnly>(type: "date", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edukacija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Putanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazivPozicije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPocetka = table.Column<DateOnly>(type: "date", nullable: false),
                    DatumZavrsetka = table.Column<DateOnly>(type: "date", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CVEdukacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    EdukacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVEdukacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVEdukacija_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVEdukacija_Edukacija_EdukacijaId",
                        column: x => x.EdukacijaId,
                        principalTable: "Edukacija",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVURL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    URLId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVURL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVURL_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVURL_URL_URLId",
                        column: x => x.URLId,
                        principalTable: "URL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVZaposlenje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    ZaposlenjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVZaposlenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVZaposlenje_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVZaposlenje_Zaposlenje_ZaposlenjeId",
                        column: x => x.ZaposlenjeId,
                        principalTable: "Zaposlenje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVEdukacija_CVId",
                table: "CVEdukacija",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVEdukacija_EdukacijaId",
                table: "CVEdukacija",
                column: "EdukacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_CVURL_CVId",
                table: "CVURL",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVURL_URLId",
                table: "CVURL",
                column: "URLId");

            migrationBuilder.CreateIndex(
                name: "IX_CVZaposlenje_CVId",
                table: "CVZaposlenje",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVZaposlenje_ZaposlenjeId",
                table: "CVZaposlenje",
                column: "ZaposlenjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVEdukacija");

            migrationBuilder.DropTable(
                name: "CVURL");

            migrationBuilder.DropTable(
                name: "CVZaposlenje");

            migrationBuilder.DropTable(
                name: "Edukacija");

            migrationBuilder.DropTable(
                name: "URL");

            migrationBuilder.DropTable(
                name: "Zaposlenje");
        }
    }
}
