

using BasicApp.DTO;
using BasicApp.Models;
using BasicApp.Utils;

namespace BasicApp.ViewModel
{
    public partial class HistoricViewModel : ViewModelBase
    {

        public HistoricViewModel()
        {

        }

        //[ObservableProperty]
        //private ObservableCollection<HistoricPokemonDTO> pokemons;

        public override async Task LoadAsync()
        {
            
            CocheDTO coche = await HttpJsonClient<CocheDTO>.Get("Coche");
            Console.Out.WriteLine("");
            /*
            Pokemons.Clear();
            List<HistoricPokemonDTO>? listaPokemon = await HttpJsonClient<List<HistoricPokemonDTO>>.Get(Constantes.MI_POKEAPI_URL);
            foreach (HistoricPokemonDTO pokemon in listaPokemon ?? [])
            {
                Pokemons.Add(pokemon);
            }
            */
        }
    
    }
}
