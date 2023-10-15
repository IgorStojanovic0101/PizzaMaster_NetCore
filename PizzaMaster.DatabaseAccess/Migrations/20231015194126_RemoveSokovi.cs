using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.Data.Migrations
{
    public partial class RemoveSokovi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sokovi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
