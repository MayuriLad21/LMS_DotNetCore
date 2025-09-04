using Microsoft.EntityFrameworkCore;
using LMS.Models.postgres;

namespace LMS.Data
{
    public class AnalyticsDbContext : DbContext
    {
        public AnalyticsDbContext(DbContextOptions<AnalyticsDbContext> options) : base(options) { }

        public DbSet<DimUser> Users { get; set; }
        public DbSet<DimCourse> Courses { get; set; }
        public DbSet<FactCourseProgress> CourseProgress { get; set; }
        public DbSet<FactEngagement> Engagements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Map to Postgres snake_case tables
            modelBuilder.Entity<DimUser>().ToTable("dim_user");
            modelBuilder.Entity<DimCourse>().ToTable("dim_course");
            modelBuilder.Entity<FactCourseProgress>().ToTable("fact_course_progress");
            modelBuilder.Entity<FactEngagement>().ToTable("fact_engagement");

            // ✅ Primary Keys
            modelBuilder.Entity<DimUser>().HasKey(u => u.UserId);
            modelBuilder.Entity<DimCourse>().HasKey(c => c.CourseId);
            modelBuilder.Entity<FactCourseProgress>().HasKey(f => new { f.UserId, f.CourseId, f.DateId });
            modelBuilder.Entity<FactEngagement>().HasKey(f => new { f.UserId, f.CourseId, f.ContentId, f.DateId });

            // ✅ Relationships
            modelBuilder.Entity<FactCourseProgress>()
                .HasOne(f => f.User)
                .WithMany(u => u.CourseProgressRecords)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<FactCourseProgress>()
                .HasOne(f => f.Course)
                .WithMany(c => c.CourseProgressRecords)
                .HasForeignKey(f => f.CourseId);

            modelBuilder.Entity<FactEngagement>()
                .HasOne(f => f.User)
                .WithMany(u => u.EngagementRecords)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<FactEngagement>()
                .HasOne(f => f.Course)
                .WithMany(c => c.EngagementRecords)
                .HasForeignKey(f => f.CourseId);

            // ✅ Seed Data
            modelBuilder.Entity<DimUser>().HasData(
                new DimUser { UserId = 1, Name = "AliceTest", Role = "Student", Department = "CS" },
                new DimUser { UserId = 2, Name = "Bob", Role = "Student", Department = "Math" },
                new DimUser { UserId = 3, Name = "Dr. Smith", Role = "Instructor", Department = "CS" }
            );

            modelBuilder.Entity<DimCourse>().HasData(
                new DimCourse { CourseId = 1, Title = "C# Basics", Category = "Programming", Difficulty = "Beginner" },
                new DimCourse { CourseId = 2, Title = "Data Science", Category = "Analytics", Difficulty = "Intermediate" }
            );

            modelBuilder.Entity<FactCourseProgress>().HasData(
                new FactCourseProgress { UserId = 1, CourseId = 1, DateId = 1, CompletionPercent = 40, TimeSpentMinutes = 120, ProgressStatus = "In Progress" },
                new FactCourseProgress { UserId = 2, CourseId = 2, DateId = 1, CompletionPercent = 70, TimeSpentMinutes = 200, ProgressStatus = "In Progress" }
            );

            modelBuilder.Entity<FactEngagement>().HasData(
                new FactEngagement { UserId = 1, CourseId = 1, ContentId = 101, DateId = 1, Views = 5, Clicks = 10, QuizAttempts = 1 },
                new FactEngagement { UserId = 2, CourseId = 2, ContentId = 202, DateId = 1, Views = 8, Clicks = 12, QuizAttempts = 2 }
            );
        }
    }
}
