using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class promjenjenNazivKolone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrojTelefona",
                table: "CV",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "CV",
                newName: "BrojTelefona");
        }
    }
}
