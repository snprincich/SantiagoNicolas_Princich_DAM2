

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

            await HttpJsonClient<CocheDTO>.Patch(Constantes.COCHE_PATH+"/13",new CocheDTO
            {
                Id = 13,
                Marca = "PruebaPost2",
                Modelo = "PruebaPost2",
            });

            List<CocheDTO> listaCoche = await HttpJsonClient<List<CocheDTO>>.Get("Coche");
            Console.Out.WriteLine("");

        }
    
    }
}
