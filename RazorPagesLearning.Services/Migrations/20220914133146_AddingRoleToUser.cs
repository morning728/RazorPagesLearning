using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesLearning.Services.Migrations
{
    public partial class AddingRoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "login", "password", "role" },
                values: new object[] { 1, "secretAdminLogin", "123456", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");
        }
    }
}
