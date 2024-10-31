using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class promjenaAtributaZaCV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisProfila",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "CV");

            migrationBuilder.AlterColumn<string>(
                name: "BrojTelefona",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kursevi",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfesionalniSazetak",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TehničkeVještine",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vještine",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Kursevi",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "ProfesionalniSazetak",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "TehničkeVještine",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Vještine",
                table: "CV");

            migrationBuilder.AlterColumn<string>(
                name: "BrojTelefona",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpisProfila",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
