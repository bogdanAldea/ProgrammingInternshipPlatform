using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChapterType = table.Column<int>(type: "int", nullable: false),
                    VersioningState = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SyllabusOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.ChapterId);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Center = table.Column<int>(type: "int", nullable: false),
                    ScheduledToStartOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedToEndOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    MaxInternsToEnroll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                });

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
                name: "VersionedModule",
                columns: table => new
                {
                    VersionedModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionedCurriculumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionedModule", x => x.VersionedModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LearningObjective = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SyllabusOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lesson_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "ChapterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.InternId);
                    table.ForeignKey(
                        name: "FK_Intern_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mentorship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mentorship_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipTrainer",
                columns: table => new
                {
                    InternshipsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipTrainer", x => new { x.InternshipsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_InternshipTrainer_Internships_InternshipsId",
                        column: x => x.InternshipsId,
                        principalTable: "Internships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipTrainer_Trainer_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "VersionNumber",
                columns: table => new
                {
                    VersionNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionedModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChapterPatch = table.Column<int>(type: "int", nullable: false),
                    LessonPatch = table.Column<int>(type: "int", nullable: false),
                    AssignmentPatch = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedByAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningResource",
                columns: table => new
                {
                    LearningResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearningResourceType = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResource", x => x.LearningResourceId);
                    table.ForeignKey(
                        name: "FK_LearningResource_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_LessonId",
                table: "Assignment",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intern_InternshipId",
                table: "Intern",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTrainer_TrainersId",
                table: "InternshipTrainer",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipVersionedCurriculum_InternshipsId",
                table: "InternshipVersionedCurriculum",
                column: "InternshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResource_LessonId",
                table: "LearningResource",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ChapterId",
                table: "Lesson",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentorship_InternshipId",
                table: "Mentorship",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionNumber_VersionedModuleId",
                table: "VersionNumber",
                column: "VersionedModuleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropTable(
                name: "InternshipTrainer");

            migrationBuilder.DropTable(
                name: "InternshipVersionedCurriculum");

            migrationBuilder.DropTable(
                name: "LearningResource");

            migrationBuilder.DropTable(
                name: "Mentorship");

            migrationBuilder.DropTable(
                name: "VersionNumber");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "VersionedCurriculum");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "VersionedModule");

            migrationBuilder.DropTable(
                name: "Chapter");
        }
    }
}
