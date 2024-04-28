using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fittness.Migrations
{
    /// <inheritdoc />
    public partial class setPalRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preparation_time",
                table: "PalateRecipes",
                newName: "PreparationTime");

            migrationBuilder.RenameColumn(
                name: "NumberOf_people",
                table: "PalateRecipes",
                newName: "NumberOfPeople");

            migrationBuilder.RenameColumn(
                name: "Difficulty_level",
                table: "PalateRecipes",
                newName: "DifficultyLevel");

            migrationBuilder.RenameColumn(
                name: "Cooking_time",
                table: "PalateRecipes",
                newName: "CookingTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreparationTime",
                table: "PalateRecipes",
                newName: "Preparation_time");

            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "PalateRecipes",
                newName: "NumberOf_people");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevel",
                table: "PalateRecipes",
                newName: "Difficulty_level");

            migrationBuilder.RenameColumn(
                name: "CookingTime",
                table: "PalateRecipes",
                newName: "Cooking_time");
        }
    }
}
