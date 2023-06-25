using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItCareerExam.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackToReviewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Reviews");
        }
    }
}
