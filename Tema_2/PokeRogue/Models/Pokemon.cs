using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRogue.Models
{
    public class Pokemon
    {
        
        public int? Id { get; set; }
        public string? PokemonName { get; set; }

        public string? ImagePath { get; set; }

        public bool? Captura { get; set; }

        public int? PokeAtaque { get; set; }

        public int? PokeHp { get; set; }
        
    }
}
