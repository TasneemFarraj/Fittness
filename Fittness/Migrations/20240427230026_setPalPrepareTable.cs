using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fittness.Migrations
{
    /// <inheritdoc />
    public partial class setPalPrepareTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalatePrepares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    step_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_7 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalatePrepares", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalatePrepares");
        }
    }
}
