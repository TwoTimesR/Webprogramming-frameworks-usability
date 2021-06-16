using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Migrations
{
    public partial class LinModelWithIdenityUsr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Studenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Studenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Studenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Studenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Studenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Studenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Docenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Docenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Docenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Docenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Docenten",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Docenten",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Docenten",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Studenten");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Docenten");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Docenten");
        }
    }
}
