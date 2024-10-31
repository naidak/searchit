using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OglasIskustvo_Oglasi_OglasId",
                table: "OglasIskustvo");

            migrationBuilder.AddForeignKey(
                name: "FK_OglasIskustvo_Oglasi_OglasId",
                table: "OglasIskustvo",
                column: "OglasId",
                principalTable: "Oglasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OglasIskustvo_Oglasi_OglasId",
                table: "OglasIskustvo");

            migrationBuilder.AddForeignKey(
                name: "FK_OglasIskustvo_Oglasi_OglasId",
                table: "OglasIskustvo",
                column: "OglasId",
                principalTable: "Oglasi",
                principalColumn: "Id");
        }
    }
}
