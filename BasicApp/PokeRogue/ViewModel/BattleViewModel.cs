using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using BasicApp.Interface;
using BasicApp.Models;
using BasicApp.Services;
using BasicApp.Utils;
using System.Windows;

namespace BasicApp.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        
        private GenerarPokemonService generarPokemonService;
        private IGestorAPIService gestorAPIService;

        [ObservableProperty]
        public Pokemon _pokemon;

        [ObservableProperty]
        public Jugador _jugador;

        private Batalla batalla;

        public BattleViewModel(GenerarPokemonService generarPokemonService, IGestorAPIService gestorAPIService, Jugador jugador) 
        {
            this.generarPokemonService = generarPokemonService;
            this.gestorAPIService = gestorAPIService;
            this.Jugador = jugador;
            GenerarPokemon();

        }

        private async Task GenerarPokemon()
        {
           batalla = App.Current.Services.GetService<Batalla>();
           Pokemon = await generarPokemonService.GetPokemon();
           Pokemon.VidaPorcentaje = "100%";
        }

        [RelayCommand]
        public void Atacar(object? parameter)
        {
            int dmg = Jugador.Atacar();
            Pokemon.PokeHpActual -= dmg;
            batalla.damageDoneTrainer += dmg;
            CalcVidaPorcentajePokemon();

            if (Pokemon.PokeHpActual > 0)
            {
                Jugador.VidaActual -= (int)Pokemon.PokeAtaque;
                batalla.damageReceivedTrainer += (int)Pokemon.PokeAtaque;
                batalla.damageDonePokemon += (int)Pokemon.PokeAtaque;
                CalcVidaPorcentajeJugador();

                if (Jugador.VidaActual <= 0)
                {
                    MessageBox.Show("GAME OVER");
                }
            }
            else
            {
                addHistoricAPI();
                GenerarPokemon();
            }
        }

        

        [RelayCommand]
        public void Escapar(object? parameter)
        {
            GenerarPokemon();
        }

        [RelayCommand]
        public void Capturar(object? parameter)
        {
            int prob = (int)(((decimal)Pokemon.PokeHpActual / (decimal)Pokemon.PokeHp) * 100);

            //PROBABILIDAD MINIMA 1%, MAXIMA 99%
            if (new Random().Next(1,102) > prob)
            {
                GestorCapturado();
            }
        }

        private void GestorCapturado()
        {
            Pokemon.Capturado = true;
            addHistoricAPI();
            Curar();
            CalcVidaPorcentajeJugador();
            GenerarPokemon();
        }

        private async Task addHistoricAPI()
        {
            batalla.dateEnd = DateTime.Now.ToString("O");
            HistoricPokemonDTO dto = await gestorAPIService.CrearHistoricDTO(Pokemon, batalla);
            gestorAPIService.AddPokemonToApi(dto);
        }



        private void Curar()
        {
            int curacion = Pokemon.Shiny == true? Jugador.VidaMaxima : (int)(Jugador.VidaMaxima*0.05);
            batalla.damageDonePokemon -= curacion;
            Jugador.VidaActual = Jugador.VidaActual + curacion <= Constantes.JUGADOR_HP_MAX ? Jugador.VidaActual + curacion : Constantes.JUGADOR_HP_MAX;
        }

        private void CalcVidaPorcentajePokemon()
        {
            Pokemon.VidaPorcentaje = calcPorcentaje(Pokemon.PokeHpActual, Pokemon.PokeHp);
        }

        private void CalcVidaPorcentajeJugador()
        {
            Jugador.VidaPorcentaje = calcPorcentaje(Jugador.VidaActual, Jugador.VidaMaxima);
        }

        private String calcPorcentaje(int? vidaActual, int? vidaMaxima)
        {
            return  (int)((double)vidaActual / (double)vidaMaxima * 100) + "%";
        }

    }
}
