using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class MigrationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a437707-eb13-45e7-a13e-42fda1b543b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44c4ad45-c1c9-4852-8d61-d5aa9d2ad579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49653e7e-a172-4094-890c-b41750e3f81c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65781022-fe05-4766-b21d-90f8234e3e60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78c1226e-d0a0-40b7-a05a-bc1b2189a6b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af5c8802-ad30-4e86-a6e5-3012c6c7e8b9");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3a437707-eb13-45e7-a13e-42fda1b543b7", null, "HR Rep", "HR REP" },
                    { "44c4ad45-c1c9-4852-8d61-d5aa9d2ad579", null, "Coordinator", "COORDINATOR" },
                    { "49653e7e-a172-4094-890c-b41750e3f81c", null, "Intern", "INTERN" },
                    { "65781022-fe05-4766-b21d-90f8234e3e60", null, "Administrator", "ADMINISTRATOR" },
                    { "78c1226e-d0a0-40b7-a05a-bc1b2189a6b7", null, "Development", "DEVELOPMENT" },
                    { "af5c8802-ad30-4e86-a6e5-3012c6c7e8b9", null, "Trainer", "TRAINER" }
                });
        }
    }
}
