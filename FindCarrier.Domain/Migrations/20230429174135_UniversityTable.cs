using Microsoft.EntityFrameworkCore.Migrations;

namespace FindCarrier.Domain.Migrations
{
    public partial class UniversityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "ApplicationUser",
                newName: "IsDeleted");

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

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "University",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolType",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Field",
                table: "University");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "University");

            migrationBuilder.DropColumn(
                name: "SchoolType",
                table: "University");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ApplicationUser",
                newName: "isDeleted");
        }
    }
}
