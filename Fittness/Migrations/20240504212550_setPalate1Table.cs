using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fittness.Migrations
{
    /// <inheritdoc />
    public partial class setPalate1Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Palates1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Palates1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Palates1",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Palates1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Palates1",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Palates1",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
