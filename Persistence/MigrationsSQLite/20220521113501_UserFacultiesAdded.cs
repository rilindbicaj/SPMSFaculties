using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.MigrationsSQLite
{
    public partial class UserFacultiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFaculties",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FacultyID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFaculties", x => new { x.UserID, x.FacultyID });
                    table.ForeignKey(
                        name: "FK_UserFaculties_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFaculties_FacultyID",
                table: "UserFaculties",
                column: "FacultyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFaculties");
        }
    }
}
