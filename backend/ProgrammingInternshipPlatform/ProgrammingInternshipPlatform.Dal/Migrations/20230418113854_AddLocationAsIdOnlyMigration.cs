using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationAsIdOnlyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Internships_LocationId",
                table: "Internships");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_LocationId",
                table: "Internships",
                column: "LocationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Internships_LocationId",
                table: "Internships");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_LocationId",
                table: "Internships",
                column: "LocationId");
        }
    }
}
