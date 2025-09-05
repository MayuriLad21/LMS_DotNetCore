using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAssessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentSubmission_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentSubmission_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assessments",
                columns: new[] { "Id", "CourseId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "C# Basics - Quiz 1" },
                    { 2, 2, "ASP.NET Core - Final Test" }
                });

            migrationBuilder.InsertData(
                table: "AssessmentSubmission",
                columns: new[] { "Id", "AssessmentId", "Score", "StartedAt", "SubmittedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 75.0, new DateTime(2025, 8, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 2, null, new DateTime(2025, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CourseId",
                table: "Assessments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentSubmission_AssessmentId",
                table: "AssessmentSubmission",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentSubmission_UserId",
                table: "AssessmentSubmission",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentSubmission");

            migrationBuilder.DropTable(
                name: "Assessments");
        }
    }
}
