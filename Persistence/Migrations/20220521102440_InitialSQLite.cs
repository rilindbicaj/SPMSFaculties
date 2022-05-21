﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialSQLite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LevelName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MajorName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorID);
                });

            migrationBuilder.CreateTable(
                name: "SeasonStatuses",
                columns: table => new
                {
                    SeasonStatusID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonStatuses", x => x.SeasonStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SemesterName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterID);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacultyName = table.Column<string>(type: "TEXT", nullable: true),
                    MajorID = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyID);
                    table.ForeignKey(
                        name: "FK_Faculties_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties_Majors_MajorID",
                        column: x => x.MajorID,
                        principalTable: "Majors",
                        principalColumn: "MajorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultySemesters",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "INTEGER", nullable: false),
                    SemesterID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySemesters", x => new { x.FacultyID, x.SemesterID });
                    table.ForeignKey(
                        name: "FK_FacultySemesters_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultySemesters_Semesters_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semesters",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemesterRegisteringSeasons",
                columns: table => new
                {
                    SemesterRegisteringSeasonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegisteringSeasonName = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Faculty = table.Column<int>(type: "INTEGER", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterRegisteringSeasons", x => x.SemesterRegisteringSeasonID);
                    table.ForeignKey(
                        name: "FK_SemesterRegisteringSeasons_FacultySemesters_Faculty_Semester",
                        columns: x => new { x.Faculty, x.Semester },
                        principalTable: "FacultySemesters",
                        principalColumns: new[] { "FacultyID", "SemesterID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterRegisteringSeasons_SeasonStatuses_CurrentStatus",
                        column: x => x.CurrentStatus,
                        principalTable: "SeasonStatuses",
                        principalColumn: "SeasonStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredSemesters",
                columns: table => new
                {
                    RegistrationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteringSeasonID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredSemesters", x => x.RegistrationID);
                    table.ForeignKey(
                        name: "FK_RegisteredSemesters_SemesterRegisteringSeasons_RegisteringSeasonID",
                        column: x => x.RegisteringSeasonID,
                        principalTable: "SemesterRegisteringSeasons",
                        principalColumn: "SemesterRegisteringSeasonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_LevelID",
                table: "Faculties",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_MajorID_LevelID",
                table: "Faculties",
                columns: new[] { "MajorID", "LevelID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacultySemesters_SemesterID",
                table: "FacultySemesters",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredSemesters_RegisteringSeasonID",
                table: "RegisteredSemesters",
                column: "RegisteringSeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterRegisteringSeasons_CurrentStatus",
                table: "SemesterRegisteringSeasons",
                column: "CurrentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterRegisteringSeasons_Faculty_Semester",
                table: "SemesterRegisteringSeasons",
                columns: new[] { "Faculty", "Semester" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RegisteredSemesters");

            migrationBuilder.DropTable(
                name: "SemesterRegisteringSeasons");

            migrationBuilder.DropTable(
                name: "FacultySemesters");

            migrationBuilder.DropTable(
                name: "SeasonStatuses");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
