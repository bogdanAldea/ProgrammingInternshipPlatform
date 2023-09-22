using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class DropedVersionNumberModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VersionNumber");

            migrationBuilder.AddColumn<string>(
                name: "VersionNumber",
                table: "VersionedModule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "VersionedModule");

            migrationBuilder.CreateTable(
                name: "VersionNumber",
                columns: table => new
                {
                    VersionNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentPatch = table.Column<int>(type: "int", nullable: false),
                    ChapterPatch = table.Column<int>(type: "int", nullable: false),
                    LessonPatch = table.Column<int>(type: "int", nullable: false),
                    VersionedModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionNumber", x => x.VersionNumberId);
                    table.ForeignKey(
                        name: "FK_VersionNumber_VersionedModule_VersionedModuleId",
                        column: x => x.VersionedModuleId,
                        principalTable: "VersionedModule",
                        principalColumn: "VersionedModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VersionNumber_VersionedModuleId",
                table: "VersionNumber",
                column: "VersionedModuleId",
                unique: true);
        }
    }
}
