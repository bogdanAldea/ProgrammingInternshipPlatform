using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class AddCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09d541e9-9548-4af1-b788-3c25d18e56ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45efbc6b-7111-4cbc-bc1e-42e82800fa44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60077d9b-21a7-405e-bc7e-1a61d7a5aedc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1c829b3-3c5c-40f4-9c26-b3a9d60316f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f50ce300-1d01-46b6-bf20-0361be1adee2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe0461a-c68e-4a50-bcc8-bef0d056cbb1");

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

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Country_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Country_CountryId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CountryId",
                table: "Locations");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09d541e9-9548-4af1-b788-3c25d18e56ca", null, "Intern", "INTERN" },
                    { "45efbc6b-7111-4cbc-bc1e-42e82800fa44", null, "Development", "DEVELOPMENT" },
                    { "60077d9b-21a7-405e-bc7e-1a61d7a5aedc", null, "Administrator", "ADMINISTRATOR" },
                    { "c1c829b3-3c5c-40f4-9c26-b3a9d60316f1", null, "Trainer", "TRAINER" },
                    { "f50ce300-1d01-46b6-bf20-0361be1adee2", null, "HR Rep", "HR REP" },
                    { "fbe0461a-c68e-4a50-bcc8-bef0d056cbb1", null, "Coordinator", "COORDINATOR" }
                });
        }
    }
}
