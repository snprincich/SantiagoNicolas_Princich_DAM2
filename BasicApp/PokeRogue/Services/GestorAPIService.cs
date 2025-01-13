using Microsoft.VisualBasic;
using BasicApp.Interface;
using BasicApp.Models;
using BasicApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BasicApp.Services
{
    public class GestorAPIService : IGestorAPIService
    {
        public async Task<HistoricPokemonDTO> CrearHistoricDTO(Pokemon pokemon, Batalla batalla)
        {
            HistoricPokemonDTO? poke = null;
            try
            {
                poke = new HistoricPokemonDTO
                {
                    //TODO GUID
                    Id = /*await HttpJsonClient<int>.Get(Constantes.MI_POKEAPI_URL + Constantes.MI_POKEAPI_LASTID) +*/ 1,
                    DateStart = batalla.dateStart,
                    DateEnd = batalla.dateEnd,
                    PokeName = pokemon.PokemonName,
                    DamageDoneTrainer = batalla.damageDoneTrainer,
                    DamageReceivedTrainer = batalla.damageReceivedTrainer,
                    DamageDonePokemon = batalla.damageDonePokemon,
                    PokeImagen = pokemon.ImagePath,
                    Capturado = pokemon.Capturado,
                    Shiny = pokemon.Shiny
                };
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
            return poke;
        }



        public async Task<HistoricPokemonDTO> GetPokemon()
        {

            string url = Constantes.MI_POKEAPI_URL;


            HistoricPokemonDTO pokemon = await HttpJsonClient<HistoricPokemonDTO>.Get(url);
            return pokemon;
        }

        public async Task AddPokemonToApi(object pokemon)
        {
            try
            {
                if (pokemon == null) return;
                var response = await HttpJsonClient<HistoricPokemonDTO>.Post(Constantes.MI_POKEAPI_URL, pokemon);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<HistoricPokemonDTO>> GetAllPokemons()
        {
            try
            {
                var pokemons = await HttpJsonClient<List<HistoricPokemonDTO>>.Get(Constantes.MI_POKEAPI_URL);
                return pokemons ?? new List<HistoricPokemonDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de la  API: {ex.Message}");
                return new List<HistoricPokemonDTO>();
            }
        }
    }
}

