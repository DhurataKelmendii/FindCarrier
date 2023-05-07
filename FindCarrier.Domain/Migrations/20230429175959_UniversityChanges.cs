using Microsoft.EntityFrameworkCore.Migrations;

namespace FindCarrier.Domain.Migrations
{
    public partial class UniversityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Exam",
                table: "University");

            migrationBuilder.DropColumn(
                name: "ExamPoints",
                table: "University");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exam",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamPoints",
                table: "University",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
