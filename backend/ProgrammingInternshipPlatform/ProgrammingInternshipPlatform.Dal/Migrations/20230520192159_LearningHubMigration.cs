using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class LearningHubMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Board_BoardId",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Project_ProjectId",
                table: "WorkItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Board",
                table: "Board");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Board",
                newName: "Boards");

            migrationBuilder.RenameIndex(
                name: "IX_Board_BoardId",
                table: "Boards",
                newName: "IX_Boards_BoardId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Boards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "BoardId");

            migrationBuilder.CreateTable(
                name: "ScheduledPresentation",
                columns: table => new
                {
                    ScheduledPresentationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledPresentation", x => x.ScheduledPresentationId);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentRequest",
                columns: table => new
                {
                    AssignmentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledPresentationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentRequest", x => x.AssignmentRequestId);
                    table.ForeignKey(
                        name: "FK_AssignmentRequest_ScheduledPresentation_ScheduledPresentationId",
                        column: x => x.ScheduledPresentationId,
                        principalTable: "ScheduledPresentation",
                        principalColumn: "ScheduledPresentationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_AssignmentRequest_AssignmentRequestId",
                        column: x => x.AssignmentRequestId,
                        principalTable: "AssignmentRequest",
                        principalColumn: "AssignmentRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_Title",
                table: "Boards",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentRequest_AssignmentId",
                table: "AssignmentRequest",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentRequest_ScheduledPresentationId",
                table: "AssignmentRequest",
                column: "ScheduledPresentationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AssignmentRequestId",
                table: "Comment",
                column: "AssignmentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentId",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPresentation_ScheduledPresentationId",
                table: "ScheduledPresentation",
                column: "ScheduledPresentationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Boards_BoardId",
                table: "Stage",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Projects_ProjectId",
                table: "WorkItem",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Boards_BoardId",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Projects_ProjectId",
                table: "WorkItem");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "AssignmentRequest");

            migrationBuilder.DropTable(
                name: "ScheduledPresentation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_Title",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "Board");

            migrationBuilder.RenameIndex(
                name: "IX_Boards_BoardId",
                table: "Board",
                newName: "IX_Board_BoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Board",
                table: "Board",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Board_BoardId",
                table: "Stage",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Project_ProjectId",
                table: "WorkItem",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
