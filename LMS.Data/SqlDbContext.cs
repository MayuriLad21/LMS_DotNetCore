using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // UserRole Relationships
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Course -> Instructor (One to Many)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(u => u.CoursesTaught)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Set precision for Fees property
            modelBuilder.Entity<Course>()
                .Property(c => c.Fees)
                .HasPrecision(18, 2);

            // Enrollment Mapping
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            //////seed data

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "System Administrator" },
                new Role { Id = 2, RoleName = "Instructor", Description = "Course Instructor" },
                new Role { Id = 3, RoleName = "Student", Description = "Enrolled Student" }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@lms.com",
                    PasswordHash = "hashed-admin", // Replace with real hash if needed
                    Age = 30,
                    Gender = "Female",
                    ContactNumber = "111-111-1111"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Instructor",
                    UserName = "instructor",
                    Email = "instructor@lms.com",
                    PasswordHash = "hashed-instructor",
                    Age = 35,
                    Gender = "Male",
                    ContactNumber = "222-222-2222"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Charlie",
                    LastName = "Student",
                    UserName = "student",
                    Email = "student@lms.com",
                    PasswordHash = "hashed-student",
                    Age = 20,
                    Gender = "Other",
                    ContactNumber = "333-333-3333"
                }
            );

            // Seed UserRoles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 2, RoleId = 2 },
                new UserRole { UserId = 3, RoleId = 3 }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "C# Basics",
                    Description = "Introduction to C# and .NET",
                    InstructorId = 2,
                    Duration = 10,
                    Fees = 499.99M
                },
                new Course
                {
                    Id = 2,
                    Title = "ASP.NET Core",
                    Description = "Building Web APIs with ASP.NET Core",
                    InstructorId = 2,
                    Duration = 15,
                    Fees = 699.99M
                }
            );

            // Seed Enrollment
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    UserId = 3,
                    CourseId = 1,
                    CompletionStatus = "InProgress",
                    Grade = "B"
                }
            );
        }
    }
}
