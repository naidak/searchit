using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class IzbirsanOpisKompanije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpisiKompanija");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpisiKompanija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojOtvorenihPozicija = table.Column<int>(type: "int", nullable: false),
                    BrojZaposlenika = table.Column<int>(type: "int", nullable: false),
                    OpisPoslovanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpisiKompanija", x => x.Id);
                });
        }
    }
}
