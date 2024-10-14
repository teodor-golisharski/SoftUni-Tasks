using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {

        }

        //DbSets
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Homework> Homeworks { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;


        //Connection configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DBConfig.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);

            modelBuilder.Entity<StudentCourse>()
                .HasKey("StudentId", "CourseId");

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);
        }
    }
}