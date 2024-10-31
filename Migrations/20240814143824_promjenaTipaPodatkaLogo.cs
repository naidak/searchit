using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class promjenaTipaPodatkaLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                 name: "LogoTemp",
                 table: "Kompanije",
                 type: "varbinary(max)",
                 nullable: true);

            // Step 2: Copy data from the old column to the temporary column with conversion
            migrationBuilder.Sql(
                   @"UPDATE [Kompanije]
                    SET [LogoTemp] = CONVERT(varbinary(max), [Logo])
                    WHERE [Logo] IS NOT NULL;"
            );

            // Step 3: Drop the original column
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Kompanije");

            // Step 4: Rename the temporary column to the original column's name
            migrationBuilder.RenameColumn(
                name: "LogoTemp",
                table: "Kompanije",
                newName: "Logo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                 name: "LogoTemp",
                 table: "Kompanije",
                 type: "nvarchar(max)",
                 nullable: true);

            migrationBuilder.Sql(
                @"UPDATE [Kompanije]
                SET [LogoTemp] = CONVERT(nvarchar(max), [Logo])
                WHERE [Logo] IS NOT NULL;"
            );

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Kompanije");

            migrationBuilder.RenameColumn(
                name: "LogoTemp",
                table: "Kompanije",
                newName: "Logo");
        }
    }
}
