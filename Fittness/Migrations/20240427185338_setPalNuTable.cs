using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fittness.Migrations
{
    /// <inheritdoc />
    public partial class setPalNuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PalateNutritions",
                newName: "protein");

            migrationBuilder.AddColumn<string>(
                name: "Fats",
                table: "PalateNutritions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "calories",
                table: "PalateNutritions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "carbohydrates",
                table: "PalateNutritions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fats",
                table: "PalateNutritions");

            migrationBuilder.DropColumn(
                name: "calories",
                table: "PalateNutritions");

            migrationBuilder.DropColumn(
                name: "carbohydrates",
                table: "PalateNutritions");

            migrationBuilder.RenameColumn(
                name: "protein",
                table: "PalateNutritions",
                newName: "Description");
        }
    }
}
