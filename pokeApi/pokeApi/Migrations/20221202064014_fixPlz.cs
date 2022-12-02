using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokeApi.Migrations
{
    /// <inheritdoc />
    public partial class fixPlz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DexId",
                table: "Pokemon",
                newName: "Dexid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dexid",
                table: "Pokemon",
                newName: "DexId");
        }
    }
}
