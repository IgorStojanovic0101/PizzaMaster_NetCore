using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.DataAccess.Migrations
{
    public partial class AddTableRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_ImageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PizzaTypes_ImageId",
                table: "PizzaTypes");

            migrationBuilder.DropIndex(
                name: "IX_PasteTypes_ImageId",
                table: "PasteTypes");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId",
                unique: true,
                filter: "([ImageId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTypes_ImageId",
                table: "PizzaTypes",
                column: "ImageId",
                unique: true,
                filter: "([ImageId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_PasteTypes_ImageId",
                table: "PasteTypes",
                column: "ImageId",
                unique: true,
                filter: "([ImageId] IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_ImageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PizzaTypes_ImageId",
                table: "PizzaTypes");

            migrationBuilder.DropIndex(
                name: "IX_PasteTypes_ImageId",
                table: "PasteTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTypes_ImageId",
                table: "PizzaTypes",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PasteTypes_ImageId",
                table: "PasteTypes",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");
        }
    }
}
