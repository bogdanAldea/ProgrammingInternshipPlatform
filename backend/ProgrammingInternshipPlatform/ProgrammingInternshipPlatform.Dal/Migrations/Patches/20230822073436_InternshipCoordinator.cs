using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations.Patches
{
    public partial class InternshipCoordinator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoordinatorId",
                table: "Internships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "Internships");
        }
    }
}
