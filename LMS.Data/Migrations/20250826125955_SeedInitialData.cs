using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "System Administrator", "Admin" },
                    { 2, "Course Instructor", "Instructor" },
                    { 3, "Enrolled Student", "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "ContactNumber", "CreatedDate", "Email", "FirstName", "Gender", "IsActive", "LastName", "ModifiedDate", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, 30, "111-111-1111", new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5157), "admin@lms.com", "Alice", "Female", true, "Admin", new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5158), "hashed-admin", "admin" },
                    { 2, 35, "222-222-2222", new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5836), "instructor@lms.com", "Bob", "Male", true, "Instructor", new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5836), "hashed-instructor", "instructor" },
                    { 3, 20, "333-333-3333", new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5838), "student@lms.com", "Charlie", "Other", true, "Student", new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5839), "hashed-student", "student" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedDate", "Description", "Duration", "Fees", "InstructorId", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6395), "Introduction to C# and .NET", 10, 499.99m, 2, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6395), "C# Basics" },
                    { 2, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6940), "Building Web APIs with ASP.NET Core", 15, 699.99m, 2, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6941), "ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "AssignedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6066) },
                    { 2, 2, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6197) },
                    { 3, 3, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6198) }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CompletionStatus", "CourseId", "EnrollmentDate", "Grade", "UserId" },
                values: new object[] { 1, "InProgress", 1, new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(7137), "B", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
