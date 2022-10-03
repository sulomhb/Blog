using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_4.Data.Migrations
{
    public partial class NicknameDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "BlogPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Now",
                table: "BlogPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Now",
                table: "BlogPosts");
        }
    }
}
