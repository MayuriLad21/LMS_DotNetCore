using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations.PostgresMigrations
{
    /// <inheritdoc />
    public partial class InitialAnalyticsSchema9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "dim_user",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Name",
                value: "AliceTest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "dim_user",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Name",
                value: "Alice");
        }
    }
}
