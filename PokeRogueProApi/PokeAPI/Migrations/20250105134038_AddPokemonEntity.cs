using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateEnd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PokeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DamageDoneTrainer = table.Column<int>(type: "int", nullable: false),
                    DamageReceivedTrainer = table.Column<int>(type: "int", nullable: false),
                    DamageDonePokemon = table.Column<int>(type: "int", nullable: true),
                    PokeImagen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Capturado = table.Column<bool>(type: "bit", nullable: false),
                    Shiny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
