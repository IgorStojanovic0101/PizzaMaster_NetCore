using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.Data.Migrations
{
    public partial class ForeignKeysImagesToPastaAndPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "PizzaTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "PasteTypes",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PasteTypes_Images_ImageId",
                table: "PasteTypes",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTypes_Images_ImageId",
                table: "PizzaTypes",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasteTypes_Images_ImageId",
                table: "PasteTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTypes_Images_ImageId",
                table: "PizzaTypes");

            migrationBuilder.DropIndex(
                name: "IX_PizzaTypes_ImageId",
                table: "PizzaTypes");

            migrationBuilder.DropIndex(
                name: "IX_PasteTypes_ImageId",
                table: "PasteTypes");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PizzaTypes");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PasteTypes");
        }
    }
}
