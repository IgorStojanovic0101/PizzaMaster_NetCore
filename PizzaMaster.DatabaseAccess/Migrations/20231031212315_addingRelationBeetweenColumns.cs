using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.DataAccess.Migrations
{
    public partial class addingRelationBeetweenColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "HomeDescs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HomeDescs_ImageId",
                table: "HomeDescs",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeDescs_Images_ImageId",
                table: "HomeDescs",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeDescs_Images_ImageId",
                table: "HomeDescs");

            migrationBuilder.DropIndex(
                name: "IX_HomeDescs_ImageId",
                table: "HomeDescs");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "HomeDescs");
        }
    }
}
