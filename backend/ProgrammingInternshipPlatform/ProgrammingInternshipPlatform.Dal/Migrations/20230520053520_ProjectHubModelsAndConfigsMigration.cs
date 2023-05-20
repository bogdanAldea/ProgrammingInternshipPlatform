using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class ProjectHubModelsAndConfigsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_UserAccount_AccountId",
                table: "Intern");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_UserAccount_AccountId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_AccountId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Intern_AccountId",
                table: "Intern");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    UrlLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Documentation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerIntern = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.BoardId);
                    table.ForeignKey(
                        name: "FK_Board_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_Stage_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Local)),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeLabel = table.Column<int>(type: "int", nullable: false),
                    PriorityLabel = table.Column<int>(type: "int", nullable: false),
                    ComplexityLabel = table.Column<int>(type: "int", nullable: false),
                    RiskLabel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Card_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intern_InternshipId",
                table: "Intern",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_BoardId",
                table: "Board",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_ProjectId",
                table: "Board",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardId",
                table: "Card",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Description",
                table: "Card",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_StageId",
                table: "Card",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Title",
                table: "Card",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stage_BoardId_Order",
                table: "Stage",
                columns: new[] { "BoardId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stage_StageId",
                table: "Stage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_Title",
                table: "Stage",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Internships_InternshipId",
                table: "Intern",
                column: "InternshipId",
                principalTable: "Internships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Internships_InternshipId",
                table: "Intern");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Intern_InternshipId",
                table: "Intern");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_AccountId",
                table: "Trainer",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intern_AccountId",
                table: "Intern",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_UserAccount_AccountId",
                table: "Intern",
                column: "AccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_UserAccount_AccountId",
                table: "Trainer",
                column: "AccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
