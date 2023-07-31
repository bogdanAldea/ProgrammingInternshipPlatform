using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations.Create
{
    public partial class TrainerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTrainer_TrainersId",
                table: "InternshipTrainer",
                column: "TrainersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternshipTrainer");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
