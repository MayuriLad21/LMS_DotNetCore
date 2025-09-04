using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(263), new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(772), new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "AssignedDate",
                value: new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "AssignedDate",
                value: new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "AssignedDate",
                value: new DateTime(2025, 8, 26, 13, 7, 6, 282, DateTimeKind.Utc).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(8710), new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(9538), new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(9540), new DateTime(2025, 8, 26, 13, 7, 6, 281, DateTimeKind.Utc).AddTicks(9540) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6395), new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6395) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6940), new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "AssignedDate",
                value: new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "AssignedDate",
                value: new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "AssignedDate",
                value: new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5157), new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5158) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5836), new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5838), new DateTime(2025, 8, 26, 12, 59, 55, 155, DateTimeKind.Utc).AddTicks(5839) });
        }
    }
}
