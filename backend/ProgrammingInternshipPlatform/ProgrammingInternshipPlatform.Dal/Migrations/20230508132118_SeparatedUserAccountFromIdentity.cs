using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    public partial class SeparatedUserAccountFromIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserAccount");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "UserAccount",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "UserAccount");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "UserAccount",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "UserAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
