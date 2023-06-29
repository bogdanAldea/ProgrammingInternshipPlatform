using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class AddLocationToCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Center",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fa3440c-9d6c-4c5d-95b9-bd56664020f5", null, "Trainer", "TRAINER" },
                    { "430f9c54-aa71-47f6-81bb-f15e36081de4", null, "HR Rep", "HR REP" },
                    { "83c723c0-7df0-4edb-b13c-04591b9a0eef", null, "Coordinator", "COORDINATOR" },
                    { "95833de9-6e18-461e-8314-e42fa2949364", null, "Development", "DEVELOPMENT" },
                    { "a15d2ba4-5f57-4a48-820a-f75eb41197b0", null, "Intern", "INTERN" },
                    { "e4231d54-8656-4a14-a7fc-4ad26a0ebf37", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fa3440c-9d6c-4c5d-95b9-bd56664020f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "430f9c54-aa71-47f6-81bb-f15e36081de4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83c723c0-7df0-4edb-b13c-04591b9a0eef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95833de9-6e18-461e-8314-e42fa2949364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a15d2ba4-5f57-4a48-820a-f75eb41197b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4231d54-8656-4a14-a7fc-4ad26a0ebf37");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Center");

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
        }
    }
}
