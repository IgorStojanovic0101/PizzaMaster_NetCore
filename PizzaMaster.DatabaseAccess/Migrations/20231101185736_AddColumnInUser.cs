using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.DataAccess.Migrations
{
    public partial class AddColumnInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Users",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Users");
        }
    }
}
