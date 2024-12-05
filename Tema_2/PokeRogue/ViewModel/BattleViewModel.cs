using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeRogue.Models;
using PokeRogue.Services;

namespace PokeRogue.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        [ObservableProperty]
        public string _vidaPorcentaje;

        private GenerarPokemonService generarPokemonService;

        [ObservableProperty]
        public Pokemon _pokemon;

        public BattleViewModel(GenerarPokemonService generarPokemonService) 
        {
            this.generarPokemonService = generarPokemonService;
            GenerarPokemon();

        }

        private async Task GenerarPokemon()
        {
           Pokemon = await generarPokemonService.GetPokemon();
           VidaPorcentaje = "100%";
        }

        [RelayCommand]
        public void Atacar(object? parameter)
        {
            Pokemon.PokeHpActual += -20;
        }

        [RelayCommand]
        public void Escapar(object? parameter)
        {
            GenerarPokemon();
        }
    }
}
