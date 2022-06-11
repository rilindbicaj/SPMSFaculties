using System.Runtime.Intrinsics.X86;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{

    public class FacultyDBContext : DbContext
    {

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        //public DbSet<Location> Locations { get; set; }
        public DbSet<SeasonStatus> SeasonStatuses { get; set; }
        public DbSet<RegisteredSemester> RegisteredSemesters { get; set; }
        public DbSet<FacultySemester> FacultySemesters { get; set; }
        public DbSet<SemesterRegisteringSeason> SemesterRegisteringSeasons { get; set; }
        public DbSet<UserFaculty> UserFaculties { get; set; }
        public FacultyDBContext(DbContextOptions<FacultyDBContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Major>(entity =>
            {
                entity.HasKey(e => e.MajorID);
            });

            builder.Entity<Level>(entity =>
            {
                entity.HasKey(e => e.LevelID);
            });

            builder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.FacultyID);

                entity.HasIndex(f => new { f.MajorID, f.LevelID })
                .IsUnique();

                entity.HasOne(f => f.Major)
                .WithMany(m => m.Faculties)
                .HasForeignKey(f => f.MajorID);

                entity.HasOne(f => f.Level)
                .WithMany(l => l.Faculties)
                .HasForeignKey(f => f.LevelID);

            });

            builder.Entity<Semester>(entity =>
            {

                entity.HasKey(e => e.SemesterID);

            });

            builder.Entity<FacultySemester>(entity =>
            {
                entity.HasKey(e => new { e.FacultyID, e.SemesterID });

                entity.HasOne(fs => fs.Faculty)
                .WithMany(f => f.FacultySemesters)
                .HasForeignKey(e => e.FacultyID);

                entity.HasOne(fs => fs.Semester)
                .WithMany(f => f.FacultySemesters)
                .HasForeignKey(e => e.SemesterID);

            });

            // builder.Entity<Location>(entity =>
            // {
            //     entity.HasKey(lo => lo.LocationID);
            // });

            builder.Entity<SeasonStatus>(entity =>
            {
                entity.HasKey(ss => ss.SeasonStatusID);

                entity.HasMany(e => e.Seasons).WithOne();

            });

            builder.Entity<SemesterRegisteringSeason>(entity =>
            {
                entity.HasKey(srs => srs.SemesterRegisteringSeasonID);

                entity.HasOne(srs => srs.FacultySemester)
                .WithMany(fs => fs.RegisteringSeasons)
                .HasForeignKey(f => new { f.Faculty, f.Semester });

                entity.HasOne(e => e.SeasonStatus)
                    .WithMany(e => e.Seasons)
                    .HasForeignKey(e => e.CurrentStatus);

            });

            builder.Entity<RegisteredSemester>(entity =>
            {
                entity.HasKey(e => e.RegistrationID);

                entity.HasOne(e => e.SemesterRegisteringSeason)
                .WithMany(e => e.RegisteredSemesters)
                .HasForeignKey(e => e.RegisteringSeasonID);
            });

            builder.Entity<UserFaculty>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.FacultyID });

                entity.HasOne(e => e.Faculty)
                .WithMany(f => f.UserFaculties)
                .HasForeignKey(e => e.FacultyID);
            });

        }

    }

}