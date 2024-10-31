using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class promjenaImenaKolone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vještine",
                table: "CV",
                newName: "Vjestine");

            migrationBuilder.RenameColumn(
                name: "TehničkeVještine",
                table: "CV",
                newName: "TehnickeVjestine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vjestine",
                table: "CV",
                newName: "Vještine");

            migrationBuilder.RenameColumn(
                name: "TehnickeVjestine",
                table: "CV",
                newName: "TehničkeVještine");
        }
    }
}
