using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.Data.Migrations
{
    public partial class NewSeedsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RestoranId", "Username" },
                values: new object[] { 1, "2232sd", "Igor", "123", 1, "igor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
