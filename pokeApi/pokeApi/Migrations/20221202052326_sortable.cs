using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokeApi.Migrations
{
    /// <inheritdoc />
    public partial class sortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DexId",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DexId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pokemon");
        }
    }
}
