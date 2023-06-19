using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class InternshipModuleConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternshipModule",
                columns: table => new
                {
                    InternshipModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipModule", x => x.InternshipModuleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternshipModule");
        }
    }
}
