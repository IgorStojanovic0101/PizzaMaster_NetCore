using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.DataAccess.Migrations
{
    public partial class AddingDropdownTableItemRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropdownName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropdownImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<bool>(type: "bit", nullable: false),
                    NavigationBar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dropdown", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DropItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropItemImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DropdownRelationItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropdownId = table.Column<int>(type: "int", nullable: true),
                    DropItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropdownRelationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropdownRelationItem_Dropdown_DropdownId",
                        column: x => x.DropdownId,
                        principalTable: "Dropdown",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DropdownRelationItem_DropItem_DropItemId",
                        column: x => x.DropItemId,
                        principalTable: "DropItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DropdownRelationItem_DropdownId",
                table: "DropdownRelationItem",
                column: "DropdownId");

            migrationBuilder.CreateIndex(
                name: "IX_DropdownRelationItem_DropItemId",
                table: "DropdownRelationItem",
                column: "DropItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DropdownRelationItem");

            migrationBuilder.DropTable(
                name: "Dropdown");

            migrationBuilder.DropTable(
                name: "DropItem");
        }
    }
}
