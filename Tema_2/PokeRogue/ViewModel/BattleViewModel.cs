using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeRogue.Models;
using PokeRogue.Services;
using System.Windows;

namespace PokeRogue.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        
        private GenerarPokemonService generarPokemonService;

        [ObservableProperty]
        public Pokemon _pokemon;

        [ObservableProperty]
        public Jugador _jugador;

        public BattleViewModel(GenerarPokemonService generarPokemonService, Jugador jugador) 
        {
            this.generarPokemonService = generarPokemonService;
            this.Jugador = jugador;
            GenerarPokemon();

        }

        private async Task GenerarPokemon()
        {
           Pokemon = await generarPokemonService.GetPokemon();
           Pokemon.VidaPorcentaje = "100%";
        }

        [RelayCommand]
        public void Atacar(object? parameter)
        {
            Pokemon.PokeHpActual -= Jugador.Atacar();
            Pokemon.VidaPorcentaje = calcPorcentaje(Pokemon.PokeHpActual, Pokemon.PokeHp);

            if (Pokemon.PokeHpActual > 0)
            {
                Jugador.VidaActual -= (int)Pokemon.PokeAtaque;
                Jugador.VidaPorcentaje = calcPorcentaje(Jugador.VidaActual, Jugador.VidaMaxima);

                if (Jugador.VidaActual <= 0)
                {
                    MessageBox.Show("GAME OVER");
                }
            }
            else
            {
                GenerarPokemon();
            }
        }

        [RelayCommand]
        public void Escapar(object? parameter)
        {
            GenerarPokemon();
        }

        private String calcPorcentaje(int? vidaActual, int? vidaMaxima)
        {
            return  (int)((double)vidaActual / (double)vidaMaxima * 100) + "%";
        }
    }
}
