using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations.Patches
{
    public partial class CenterToInternship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Center",
                table: "Internships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Center",
                table: "Internships");
        }
    }
}
