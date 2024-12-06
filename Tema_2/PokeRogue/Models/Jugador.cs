using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRogue.Models
{
    public partial class Jugador : ObservableObject
    {
        public int VidaMaxima { get; } = 1000;

        [ObservableProperty]
        public int _vidaActual;

        [ObservableProperty]
        public string _vidaPorcentaje;

        public Jugador()
        {
            this.VidaActual = VidaMaxima;
        }

        public int Atacar()
        {
            return new Random().Next(0, 40);
        }
    }
}
