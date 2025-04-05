using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class posiljalaca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosiljalacId",
                table: "PorukeKorisnici",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PorukeKorisnici_PosiljalacId",
                table: "PorukeKorisnici",
                column: "PosiljalacId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PorukeKorisnici_PosiljalacId",
                table: "PorukeKorisnici");

            migrationBuilder.DropColumn(
                name: "PosiljalacId",
                table: "PorukeKorisnici");
        }
    }
}
