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
                name: "GeneralCurriculumManagement.Topics",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicType = table.Column<int>(type: "int", nullable: false),
                    VersioningState = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SyllabusOrder = table.Column<int>(type: "int", nullable: false),
                    TempId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCurriculumManagement.Topics", x => x.TopicId);
                    table.UniqueConstraint("AK_GeneralCurriculumManagement.Topics_TempId", x => x.TempId);
                });

            migrationBuilder.CreateTable(
                name: "InternshipManagement.Internships",
                columns: table => new
                {
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedGraduationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternshipStatus = table.Column<int>(type: "int", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    MaxInternsToEnroll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipManagement.Internships", x => x.InternshipId);
                });

            migrationBuilder.CreateTable(
                name: "InternshipManagement.Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipManagement.Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralCurriculumManagement.Lessons",
                columns: table => new
                {
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TopicOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCurriculumManagement.Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_GeneralCurriculumManagement.Lessons_GeneralCurriculumManagement.Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "GeneralCurriculumManagement.Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipManagement.Interns",
                columns: table => new
                {
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipManagement.Interns", x => x.InternId);
                    table.ForeignKey(
                        name: "FK_InternshipManagement.Interns_InternshipManagement.Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "InternshipManagement.Internships",
                        principalColumn: "InternshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipManagement.Mentorships",
                columns: table => new
                {
                    MentorshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipManagement.Mentorships", x => x.MentorshipId);
                    table.ForeignKey(
                        name: "FK_InternshipManagement.Mentorships_InternshipManagement.Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "InternshipManagement.Internships",
                        principalColumn: "InternshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipManagement.AssignedTrainers",
                columns: table => new
                {
                    InternshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipManagement.AssignedTrainers", x => new { x.TrainerId, x.InternshipId });
                    table.ForeignKey(
                        name: "FK_InternshipManagement.AssignedTrainers_InternshipManagement.Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "InternshipManagement.Internships",
                        principalColumn: "InternshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipManagement.AssignedTrainers_InternshipManagement.Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "InternshipManagement.Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralCurriculumManagement.Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCurriculumManagement.Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_GeneralCurriculumManagement.Assignments_GeneralCurriculumManagement.Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "GeneralCurriculumManagement.Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralCurriculumManagement.LearningResources",
                columns: table => new
                {
                    LearningResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceType = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCurriculumManagement.LearningResources", x => x.LearningResourceId);
                    table.ForeignKey(
                        name: "FK_GeneralCurriculumManagement.LearningResources_GeneralCurriculumManagement.Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "GeneralCurriculumManagement.Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralCurriculumManagement.Assignments_LessonId",
                table: "GeneralCurriculumManagement.Assignments",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralCurriculumManagement.LearningResources_LessonId",
                table: "GeneralCurriculumManagement.LearningResources",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralCurriculumManagement.Lessons_TopicId",
                table: "GeneralCurriculumManagement.Lessons",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipManagement.AssignedTrainers_InternshipId",
                table: "InternshipManagement.AssignedTrainers",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipManagement.Interns_InternshipId",
                table: "InternshipManagement.Interns",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipManagement.Mentorships_InternshipId",
                table: "InternshipManagement.Mentorships",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_VersionNumber",
                table: "Modules",
                column: "VersionNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralCurriculumManagement.Assignments");

            migrationBuilder.DropTable(
                name: "GeneralCurriculumManagement.LearningResources");

            migrationBuilder.DropTable(
                name: "InternshipManagement.AssignedTrainers");

            migrationBuilder.DropTable(
                name: "InternshipManagement.Interns");

            migrationBuilder.DropTable(
                name: "InternshipManagement.Mentorships");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "GeneralCurriculumManagement.Lessons");

            migrationBuilder.DropTable(
                name: "InternshipManagement.Trainers");

            migrationBuilder.DropTable(
                name: "InternshipManagement.Internships");

            migrationBuilder.DropTable(
                name: "GeneralCurriculumManagement.Topics");
        }
    }
}
