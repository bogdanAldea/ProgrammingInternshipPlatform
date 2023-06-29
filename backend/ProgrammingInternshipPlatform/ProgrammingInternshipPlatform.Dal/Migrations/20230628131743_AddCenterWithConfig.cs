using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class AddCenterWithConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Company_CompanyId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Locations_CenterId",
                table: "Internships");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Country_CountryId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10a5154c-efe0-4ef5-a22a-00929872febe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2302bcb8-388b-47a1-94e3-fb25b7629618");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3853e6c5-4e67-4378-b7a7-3e76e75419db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ccdae4a-b6a7-4cb0-8d94-c9335dc737f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d13ed100-25d7-4822-b4f7-b4a6cb3c21c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e453aa2c-993b-489f-a780-7757836411b3");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Center");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CountryId",
                table: "Center",
                newName: "IX_Center_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center",
                table: "Center",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09757cf9-9de8-48f5-9d41-8a76e419f032", null, "Development", "DEVELOPMENT" },
                    { "201c0a65-f73c-45f5-9499-a38b19d59764", null, "HR Rep", "HR REP" },
                    { "5fdbd389-6e8f-4010-8f4e-c3cac5c39f7d", null, "Administrator", "ADMINISTRATOR" },
                    { "7f4d7a75-79fc-45ff-8cc6-e07c10341953", null, "Coordinator", "COORDINATOR" },
                    { "8566f806-2f0f-46bc-825b-0af0c5d78c7e", null, "Intern", "INTERN" },
                    { "db7be42a-8167-4636-be98-8619b1554252", null, "Trainer", "TRAINER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Center_Country_CountryId",
                table: "Center",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Companies_CompanyId",
                table: "Country",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Center_CenterId",
                table: "Internships",
                column: "CenterId",
                principalTable: "Center",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Center_Country_CountryId",
                table: "Center");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_Companies_CompanyId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Center_CenterId",
                table: "Internships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center",
                table: "Center");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09757cf9-9de8-48f5-9d41-8a76e419f032");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "201c0a65-f73c-45f5-9499-a38b19d59764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fdbd389-6e8f-4010-8f4e-c3cac5c39f7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f4d7a75-79fc-45ff-8cc6-e07c10341953");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8566f806-2f0f-46bc-825b-0af0c5d78c7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7be42a-8167-4636-be98-8619b1554252");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Center",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_Center_CountryId",
                table: "Locations",
                newName: "IX_Locations_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10a5154c-efe0-4ef5-a22a-00929872febe", null, "HR Rep", "HR REP" },
                    { "2302bcb8-388b-47a1-94e3-fb25b7629618", null, "Development", "DEVELOPMENT" },
                    { "3853e6c5-4e67-4378-b7a7-3e76e75419db", null, "Administrator", "ADMINISTRATOR" },
                    { "5ccdae4a-b6a7-4cb0-8d94-c9335dc737f3", null, "Coordinator", "COORDINATOR" },
                    { "d13ed100-25d7-4822-b4f7-b4a6cb3c21c1", null, "Trainer", "TRAINER" },
                    { "e453aa2c-993b-489f-a780-7757836411b3", null, "Intern", "INTERN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Company_CompanyId",
                table: "Country",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Locations_CenterId",
                table: "Internships",
                column: "CenterId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Country_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
