using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesLearning.Services.Migrations
{
    public partial class AddingUserLoginToLocationClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLogin",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLogin",
                table: "Locations");
        }
    }
}
