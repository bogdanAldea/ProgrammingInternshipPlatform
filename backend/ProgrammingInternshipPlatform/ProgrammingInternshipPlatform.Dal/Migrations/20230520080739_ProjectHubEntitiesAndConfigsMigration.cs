using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class ProjectHubEntitiesAndConfigsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_Project_ProjectId",
                table: "Board");

            migrationBuilder.DropIndex(
                name: "IX_Card_Description",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_Title",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Board_ProjectId",
                table: "Board");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "ComplexityLabel",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "PriorityLabel",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "RiskLabel",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "TypeLabel",
                table: "Card");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOn",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedOn",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkItemId",
                table: "Card",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    WorkItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Item = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Complexity = table.Column<int>(type: "int", nullable: false),
                    RiskLabel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.WorkItemId);
                    table.ForeignKey(
                        name: "FK_WorkItem_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcceptanceCriterion",
                columns: table => new
                {
                    AcceptanceCriterionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetCondition = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptanceCriterion", x => x.AcceptanceCriterionId);
                    table.ForeignKey(
                        name: "FK_AcceptanceCriterion_WorkItem_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "WorkItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptanceCriterion_AcceptanceCriterionId",
                table: "AcceptanceCriterion",
                column: "AcceptanceCriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptanceCriterion_WorkItemId",
                table: "AcceptanceCriterion",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_ProjectId",
                table: "WorkItem",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_WorkItemId",
                table: "WorkItem",
                column: "WorkItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptanceCriterion");

            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropColumn(
                name: "CompletedOn",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "StartedOn",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "WorkItemId",
                table: "Card");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "ComplexityLabel",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Card",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Card",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PriorityLabel",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskLabel",
                table: "Card",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Card",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeLabel",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Card_Description",
                table: "Card",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_Title",
                table: "Card",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Board_ProjectId",
                table: "Board",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Project_ProjectId",
                table: "Board",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
