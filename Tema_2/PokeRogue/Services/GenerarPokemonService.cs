using Microsoft.VisualBasic;
using PokeRogue.Models;
using PokeRogue.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRogue.Services
{
    public class GenerarPokemonService
    {
        
        public async Task<Pokemon> GetPokemon()
        {
            Random rnd = new Random();

            //Obtener los detalles del Pokémon seleccionado de al Api de forma aleatoria
            PokemonJson? pokemonDetalles = await HttpJsonClient<PokemonJson>.Get(Constantes.POKE_URL + rnd.Next(1, 501));

            if (pokemonDetalles == null)
            {
                return null;
            }

            bool esShiny = false;
            Random pokemonShiny = new Random();
            if (pokemonShiny.Next(100) < 5) // 5% de probabilidad
            {
                esShiny = true;
            }

            return CrearPokemon(pokemonDetalles, esShiny);
        }

        private static Pokemon CrearPokemon(PokemonJson? pokemonDetalles, bool esShiny)
        {
            //Crear un objeto Pokémon con la información obtenida

            string? pokemonImage;
            switch (esShiny)
            {
                case true: pokemonImage = pokemonDetalles?.Sprites?.Front_shiny;
                    break;
                case false: pokemonImage = pokemonDetalles?.Sprites?.Front_default;
                    break;
            }

            var pokemon = new Pokemon
            {
                Id = pokemonDetalles?.Id,
                ImagePath = pokemonImage,
                PokemonName = pokemonDetalles?.Name,
                PokeAtaque = pokemonDetalles?.ListaStats?.FirstOrDefault(x => x.Stat?.Name == Constantes.ATTACK)?.Base_stat,
                PokeHp = pokemonDetalles?.ListaStats?.FirstOrDefault(x => x.Stat?.Name == Constantes.HP)?.Base_stat,
                Captura = esShiny
            };

            return pokemon;
        }
    }
}
