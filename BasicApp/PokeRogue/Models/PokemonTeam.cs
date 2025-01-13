using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicApp.Models
{
    public class PokemonTeam
    {
        public string PokeName { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public bool Shiny { get; set; }
        public bool Capturado { get; set; }

    }
}
