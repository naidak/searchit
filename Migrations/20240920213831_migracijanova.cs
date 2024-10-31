using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class migracijanova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompanijaLokacija");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KompanijaLokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KompanijaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompanijaLokacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KompanijaLokacija_Kompanije_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanije",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KompanijaLokacija_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KompanijaLokacija_KompanijaId",
                table: "KompanijaLokacija",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KompanijaLokacija_LokacijaId",
                table: "KompanijaLokacija",
                column: "LokacijaId");
        }
    }
}
