using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class VersionedCurriculum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VersionedCurriculumId",
                table: "VersionedModule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "VersionedOnDate",
                table: "VersionedModule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "VersionedCurriculum",
                columns: table => new
                {
                    VersionedCurriculumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionedCurriculum", x => x.VersionedCurriculumId);
                });

            migrationBuilder.CreateTable(
                name: "InternshipVersionedCurriculum",
                columns: table => new
                {
                    CurriculaVersionedCurriculumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipVersionedCurriculum", x => new { x.CurriculaVersionedCurriculumId, x.InternshipsId });
                    table.ForeignKey(
                        name: "FK_InternshipVersionedCurriculum_Internships_InternshipsId",
                        column: x => x.InternshipsId,
                        principalTable: "Internships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipVersionedCurriculum_VersionedCurriculum_CurriculaVersionedCurriculumId",
                        column: x => x.CurriculaVersionedCurriculumId,
                        principalTable: "VersionedCurriculum",
                        principalColumn: "VersionedCurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternshipVersionedCurriculum_InternshipsId",
                table: "InternshipVersionedCurriculum",
                column: "InternshipsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternshipVersionedCurriculum");

            migrationBuilder.DropTable(
                name: "VersionedCurriculum");

            migrationBuilder.DropColumn(
                name: "VersionedCurriculumId",
                table: "VersionedModule");

            migrationBuilder.DropColumn(
                name: "VersionedOnDate",
                table: "VersionedModule");
        }
    }
}
