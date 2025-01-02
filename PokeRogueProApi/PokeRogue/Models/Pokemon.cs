using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRogue.Models
{
    public partial class Pokemon : ObservableObject
    {
        
        public int Id { get; set; }
        public string? PokemonName { get; set; }

        public string? ImagePath { get; set; }

        public bool Shiny { get; set; }

        public int? PokeAtaque { get; set; }

        public int? PokeHp { get; set; }

        public bool Capturado { get; set; }

        [ObservableProperty]
        public int? _pokeHpActual;

        [ObservableProperty]
        public string _vidaPorcentaje;

    }
}
