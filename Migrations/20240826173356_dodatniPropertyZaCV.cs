using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class dodatniPropertyZaCV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KandidatId",
                table: "CV",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CV_KandidatId",
                table: "CV",
                column: "KandidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_CV_Kandidati_KandidatId",
                table: "CV",
                column: "KandidatId",
                principalTable: "Kandidati",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CV_Kandidati_KandidatId",
                table: "CV");

            migrationBuilder.DropIndex(
                name: "IX_CV_KandidatId",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "KandidatId",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "CV");
        }
    }
}
