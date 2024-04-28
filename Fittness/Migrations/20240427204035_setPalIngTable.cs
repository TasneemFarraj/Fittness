using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fittness.Migrations
{
    /// <inheritdoc />
    public partial class setPalIngTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalateIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_7 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalateIngredients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalateIngredients");
        }
    }
}
