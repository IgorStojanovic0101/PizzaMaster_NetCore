using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.DataAccess.Migrations
{
    public partial class RestoranIdAllowedNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Restorans_RestoranId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RestoranId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Restorans_RestoranId",
                table: "Users",
                column: "RestoranId",
                principalTable: "Restorans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Restorans_RestoranId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RestoranId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Restorans_RestoranId",
                table: "Users",
                column: "RestoranId",
                principalTable: "Restorans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
