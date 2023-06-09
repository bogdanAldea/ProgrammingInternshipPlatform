using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class InternshipTrainerInternMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
