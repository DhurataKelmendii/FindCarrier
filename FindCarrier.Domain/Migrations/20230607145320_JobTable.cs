using Microsoft.EntityFrameworkCore.Migrations;

namespace FindCarrier.Domain.Migrations
{
    public partial class JobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Deadline",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Job");
        }
    }
}
