using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class OrganisationModelingConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Locations_LocationId",
                table: "Internships");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Company_CompanyId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Center",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CompanyId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Center",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Locations",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Internships",
                newName: "CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Internships_LocationId",
                table: "Internships",
                newName: "IX_Internships_CenterId");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Country_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CompanyId",
                table: "Country",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Locations_CenterId",
                table: "Internships",
                column: "CenterId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Locations_CenterId",
                table: "Internships");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Locations",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CenterId",
                table: "Internships",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Internships_CenterId",
                table: "Internships",
                newName: "IX_Internships_LocationId");

            migrationBuilder.AddColumn<string>(
                name: "Center",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Center",
                table: "Locations",
                column: "Center",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CompanyId",
                table: "Locations",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Locations_LocationId",
                table: "Internships",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Company_CompanyId",
                table: "Locations",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
