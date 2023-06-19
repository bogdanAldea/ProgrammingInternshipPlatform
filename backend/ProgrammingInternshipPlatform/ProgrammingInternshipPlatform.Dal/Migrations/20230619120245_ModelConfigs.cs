using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class ModelConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkItem_WorkItemId",
                table: "WorkItem");

            migrationBuilder.DropIndex(
                name: "IX_Stage_StageId",
                table: "Stage");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledPresentation_ScheduledPresentationId",
                table: "ScheduledPresentation");

            migrationBuilder.DropIndex(
                name: "IX_Module_ModuleId",
                table: "Module");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LessonId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Company_Id",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Card_CardId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Boards_BoardId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentRequest_AssignmentId",
                table: "AssignmentRequest");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_AssignmentId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_AcceptanceCriterion_AcceptanceCriterionId",
                table: "AcceptanceCriterion");

            migrationBuilder.AddColumn<int>(
                name: "GraduationStatus",
                table: "Intern",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraduationStatus",
                table: "Intern");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_WorkItemId",
                table: "WorkItem",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_StageId",
                table: "Stage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPresentation_ScheduledPresentationId",
                table: "ScheduledPresentation",
                column: "ScheduledPresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_ModuleId",
                table: "Module",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LessonId",
                table: "Lesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Id",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentId",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardId",
                table: "Card",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_BoardId",
                table: "Boards",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentRequest_AssignmentId",
                table: "AssignmentRequest",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignmentId",
                table: "Assignment",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptanceCriterion_AcceptanceCriterionId",
                table: "AcceptanceCriterion",
                column: "AcceptanceCriterionId");
        }
    }
}
