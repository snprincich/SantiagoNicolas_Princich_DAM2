using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRogue.Models
{
    public class Batalla
    {
        public string dateStart {  get; set; }
        public string dateEnd { get; set; }
        public int damageDoneTrainer { get; set; } = 0;
        public int damageReceivedTrainer { get; set; } = 0;
        public int damageDonePokemon { get; set; } = 0;

        public Batalla()
        {
            dateStart = DateTime.Now.ToString("O");
        }
    }
}
