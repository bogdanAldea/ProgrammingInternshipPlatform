using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class TrainerInternshipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Trainer_TrainerId",
                table: "Internships");

            migrationBuilder.DropIndex(
                name: "IX_Internships_TrainerId",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Internships");

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

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTrainer_TrainersId",
                table: "InternshipTrainer",
                column: "TrainersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternshipTrainer");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "Internships",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Internships_TrainerId",
                table: "Internships",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Trainer_TrainerId",
                table: "Internships",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id");
        }
    }
}
