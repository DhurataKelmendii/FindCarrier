using Microsoft.EntityFrameworkCore.Migrations;

namespace FindCarrier.Domain.Migrations
{
    public partial class attrUni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "University",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "University");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "University");
        }
    }
}
