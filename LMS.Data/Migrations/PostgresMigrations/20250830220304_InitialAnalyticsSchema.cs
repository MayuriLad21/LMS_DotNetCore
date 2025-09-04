using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Data.Migrations.PostgresMigrations
{
    /// <inheritdoc />
    public partial class InitialAnalyticsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dim_course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Difficulty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dim_course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "dim_user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dim_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "fact_course_progress",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    DateId = table.Column<int>(type: "integer", nullable: false),
                    CompletionPercent = table.Column<double>(type: "double precision", nullable: false),
                    TimeSpentMinutes = table.Column<int>(type: "integer", nullable: false),
                    ProgressStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fact_course_progress", x => new { x.UserId, x.CourseId, x.DateId });
                    table.ForeignKey(
                        name: "FK_fact_course_progress_dim_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "dim_course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fact_course_progress_dim_user_UserId",
                        column: x => x.UserId,
                        principalTable: "dim_user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fact_engagement",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    ContentId = table.Column<int>(type: "integer", nullable: false),
                    DateId = table.Column<int>(type: "integer", nullable: false),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    Clicks = table.Column<int>(type: "integer", nullable: false),
                    QuizAttempts = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fact_engagement", x => new { x.UserId, x.CourseId, x.ContentId, x.DateId });
                    table.ForeignKey(
                        name: "FK_fact_engagement_dim_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "dim_course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fact_engagement_dim_user_UserId",
                        column: x => x.UserId,
                        principalTable: "dim_user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dim_course",
                columns: new[] { "CourseId", "Category", "Difficulty", "Title" },
                values: new object[,]
                {
                    { 1, "Programming", "Beginner", "C# Basics" },
                    { 2, "Analytics", "Intermediate", "Data Science" }
                });

            migrationBuilder.InsertData(
                table: "dim_user",
                columns: new[] { "UserId", "Department", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "CS", "Alice", "Student" },
                    { 2, "Math", "Bob", "Student" },
                    { 3, "CS", "Dr. Smith", "Instructor" }
                });

            migrationBuilder.InsertData(
                table: "fact_course_progress",
                columns: new[] { "CourseId", "DateId", "UserId", "CompletionPercent", "ProgressStatus", "TimeSpentMinutes" },
                values: new object[,]
                {
                    { 1, 1, 1, 40.0, "In Progress", 120 },
                    { 2, 1, 2, 70.0, "In Progress", 200 }
                });

            migrationBuilder.InsertData(
                table: "fact_engagement",
                columns: new[] { "ContentId", "CourseId", "DateId", "UserId", "Clicks", "QuizAttempts", "Views" },
                values: new object[,]
                {
                    { 101, 1, 1, 1, 10, 1, 5 },
                    { 202, 2, 1, 2, 12, 2, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_fact_course_progress_CourseId",
                table: "fact_course_progress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_fact_engagement_CourseId",
                table: "fact_engagement",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fact_course_progress");

            migrationBuilder.DropTable(
                name: "fact_engagement");

            migrationBuilder.DropTable(
                name: "dim_course");

            migrationBuilder.DropTable(
                name: "dim_user");
        }
    }
}
