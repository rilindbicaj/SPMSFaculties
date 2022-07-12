using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class StudentGuiid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "RegisteredSemesters");

            migrationBuilder.AddColumn<Guid>(
                name: "Student",
                table: "RegisteredSemesters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student",
                table: "RegisteredSemesters");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "RegisteredSemesters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
