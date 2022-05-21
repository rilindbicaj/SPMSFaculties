﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.MigrationsSQLite
{
    [DbContext(typeof(FacultyDBContext))]
    [Migration("20220521113501_UserFacultiesAdded")]
    partial class UserFacultiesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.Property<int>("FacultyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FacultyName")
                        .HasColumnType("TEXT");

                    b.Property<int>("LevelID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FacultyID");

                    b.HasIndex("LevelID");

                    b.HasIndex("MajorID", "LevelID")
                        .IsUnique();

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Domain.FacultySemester", b =>
                {
                    b.Property<int>("FacultyID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemesterID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FacultyID", "SemesterID");

                    b.HasIndex("SemesterID");

                    b.ToTable("FacultySemesters");
                });

            modelBuilder.Entity("Domain.Level", b =>
                {
                    b.Property<int>("LevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LevelName")
                        .HasColumnType("TEXT");

                    b.HasKey("LevelID");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Major", b =>
                {
                    b.Property<int>("MajorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MajorName")
                        .HasColumnType("TEXT");

                    b.HasKey("MajorID");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("Domain.RegisteredSemester", b =>
                {
                    b.Property<int>("RegistrationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegisteringSeasonID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RegistrationID");

                    b.HasIndex("RegisteringSeasonID");

                    b.ToTable("RegisteredSemesters");
                });

            modelBuilder.Entity("Domain.SeasonStatus", b =>
                {
                    b.Property<int>("SeasonStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("SeasonStatusID");

                    b.ToTable("SeasonStatuses");
                });

            modelBuilder.Entity("Domain.Semester", b =>
                {
                    b.Property<int>("SemesterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SemesterName")
                        .HasColumnType("TEXT");

                    b.HasKey("SemesterID");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("Domain.SemesterRegisteringSeason", b =>
                {
                    b.Property<int>("SemesterRegisteringSeasonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Faculty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegisteringSeasonName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("SemesterRegisteringSeasonID");

                    b.HasIndex("CurrentStatus");

                    b.HasIndex("Faculty", "Semester");

                    b.ToTable("SemesterRegisteringSeasons");
                });

            modelBuilder.Entity("Domain.UserFaculty", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserID", "FacultyID");

                    b.HasIndex("FacultyID");

                    b.ToTable("UserFaculties");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.HasOne("Domain.Level", "Level")
                        .WithMany("Faculties")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Major", "Major")
                        .WithMany("Faculties")
                        .HasForeignKey("MajorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("Domain.FacultySemester", b =>
                {
                    b.HasOne("Domain.Faculty", "Faculty")
                        .WithMany("FacultySemesters")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Semester", "Semester")
                        .WithMany("FacultySemesters")
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("Domain.RegisteredSemester", b =>
                {
                    b.HasOne("Domain.SemesterRegisteringSeason", "SemesterRegisteringSeason")
                        .WithMany("RegisteredSemesters")
                        .HasForeignKey("RegisteringSeasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SemesterRegisteringSeason");
                });

            modelBuilder.Entity("Domain.SemesterRegisteringSeason", b =>
                {
                    b.HasOne("Domain.SeasonStatus", "SeasonStatus")
                        .WithMany("Seasons")
                        .HasForeignKey("CurrentStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.FacultySemester", "FacultySemester")
                        .WithMany("RegisteringSeasons")
                        .HasForeignKey("Faculty", "Semester")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacultySemester");

                    b.Navigation("SeasonStatus");
                });

            modelBuilder.Entity("Domain.UserFaculty", b =>
                {
                    b.HasOne("Domain.Faculty", "Faculty")
                        .WithMany("UserFaculties")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.Navigation("FacultySemesters");

                    b.Navigation("UserFaculties");
                });

            modelBuilder.Entity("Domain.FacultySemester", b =>
                {
                    b.Navigation("RegisteringSeasons");
                });

            modelBuilder.Entity("Domain.Level", b =>
                {
                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("Domain.Major", b =>
                {
                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("Domain.SeasonStatus", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("Domain.Semester", b =>
                {
                    b.Navigation("FacultySemesters");
                });

            modelBuilder.Entity("Domain.SemesterRegisteringSeason", b =>
                {
                    b.Navigation("RegisteredSemesters");
                });
#pragma warning restore 612, 618
        }
    }
}