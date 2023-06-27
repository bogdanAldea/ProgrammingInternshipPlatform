using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class IdentityRolesSeedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
