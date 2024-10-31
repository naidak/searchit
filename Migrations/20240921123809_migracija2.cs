using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class migracija2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LokacijaId",
                table: "Kompanije",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Kompanije_LokacijaId",
                table: "Kompanije",
                column: "LokacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kompanije_Lokacija_LokacijaId",
                table: "Kompanije",
                column: "LokacijaId",
                principalTable: "Lokacija",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kompanije_Lokacija_LokacijaId",
                table: "Kompanije");

            migrationBuilder.DropIndex(
                name: "IX_Kompanije_LokacijaId",
                table: "Kompanije");

            migrationBuilder.DropColumn(
                name: "LokacijaId",
                table: "Kompanije");
        }
    }
}
