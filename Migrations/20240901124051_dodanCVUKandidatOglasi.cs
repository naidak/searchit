using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class dodanCVUKandidatOglasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "KandidatiOglasi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiOglasi_CVId",
                table: "KandidatiOglasi",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_KandidatiOglasi_CV_CVId",
                table: "KandidatiOglasi",
                column: "CVId",
                principalTable: "CV",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KandidatiOglasi_CV_CVId",
                table: "KandidatiOglasi");

            migrationBuilder.DropIndex(
                name: "IX_KandidatiOglasi_CVId",
                table: "KandidatiOglasi");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "KandidatiOglasi");
        }
    }
}
