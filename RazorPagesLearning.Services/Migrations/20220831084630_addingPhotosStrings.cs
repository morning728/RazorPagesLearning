using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesLearning.Services.Migrations
{
    public partial class addingPhotosStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "PosX",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosY",
                table: "Events",
                type: "int",
                nullable: true);
        }
    }
}
