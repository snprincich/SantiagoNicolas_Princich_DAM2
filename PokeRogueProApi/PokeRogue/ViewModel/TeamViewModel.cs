using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.VisualBasic;
using PokeRogue.Models;
using PokeRogue.Services;
using PokeRogue.Utils;
using System.Collections.ObjectModel;

namespace PokeRogue.ViewModel
{
    public partial class TeamViewModel : ViewModelBase
    {

        //public ColorShinyService ColorShinyService { get; set; }
        public TeamViewModel(ColorShinyService colorShinyService)
        {
            listaPokemons = new ObservableCollection<PokemonTeam>();
            //this.ColorShinyService = colorShinyService;
        }


        [ObservableProperty]
        private ObservableCollection<PokemonTeam> listaPokemons;

        public override async Task LoadAsync()
        {
            List<HistoricPokemonDTO> listaPokemon = await HttpJsonClient<List<HistoricPokemonDTO>>.Get(Constantes.MI_POKEAPI_URL);
            if (listaPokemon != null)
            {
                var pokemonList = listaPokemon
               .Where(p => !string.IsNullOrEmpty(p.PokeName) && p.Capturado)
               .GroupBy(p => p.PokeName)
               .Select(g => new PokemonTeam
               {
                   PokeName = g.Key,
                   Image = g.FirstOrDefault(p => p.Shiny)?.PokeImagen ?? g.First().PokeImagen,
                   Shiny = g.First().Shiny,
                   Count = g.Count(),
                   Capturado = true
               })
               .ToList();
                ListaPokemons.Clear();
                try
                {

                    foreach (var poke in pokemonList)
                    {

                        listaPokemons.Add(poke);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }


        }

    }
}
