using CommunityToolkit.Mvvm.ComponentModel;
using PokeRogue.Models;
using PokeRogue.Services;

namespace PokeRogue.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        [ObservableProperty]
        public int _ataque;
        [ObservableProperty]
        public int _vidaActual;
        [ObservableProperty]
        public int _vidaMax;
        [ObservableProperty]
        public string _vidaPorcentaje;
        [ObservableProperty]
        public string _imagen;


        private GenerarPokemonService generarPokemonService;

        private Pokemon pokemon;

        public BattleViewModel(GenerarPokemonService generarPokemonService) 
        {
            this.generarPokemonService = generarPokemonService;
            GenerarPokemon();

        }

        private async Task GenerarPokemon()
        {
           pokemon = await generarPokemonService.GetPokemon();
           Ataque = (int)pokemon.PokeAtaque;
           VidaMax = (int)pokemon.PokeHp;
           VidaActual = VidaMax;
           VidaPorcentaje = "100%";
           Imagen = pokemon.ImagePath;
        }
    }
}
