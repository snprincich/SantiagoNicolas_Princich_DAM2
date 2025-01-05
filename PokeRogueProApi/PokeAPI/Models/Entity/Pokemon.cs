using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAPI.Models.Entity
{
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DateStart { get; set; }

        [Required]
        [MaxLength(50)]
        public string DateEnd { get; set; }

        [MaxLength(50)]
        public string? PokeName { get; set; }

        [Required]
        public int DamageDoneTrainer { get; set; }

        [Required]
        public int DamageReceivedTrainer { get; set; }

        public int? DamageDonePokemon { get; set; }

        [MaxLength(250)]
        public string? PokeImagen { get; set; }

        [Required]
        public bool Capturado { get; set; }

        [Required]
        public bool Shiny { get; set; }
    }
}
