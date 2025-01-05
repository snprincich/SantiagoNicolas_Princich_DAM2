using System.ComponentModel.DataAnnotations;

namespace PokeAPI.Models.DTOs.PokemonDTO
{
    public class CreatePokemonDTO
    {
        [Required(ErrorMessage = "DateStart is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string DateStart { get; set; }

        [Required(ErrorMessage = "DateEnd is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string DateEnd { get; set; }

        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string? PokeName { get; set; }

        [Required(ErrorMessage = "DamageDoneTrainer is required")]
        public int DamageDoneTrainer { get; set; }

        [Required(ErrorMessage = "DamageReceivedTrainer is required")]
        public int DamageReceivedTrainer { get; set; }

        public int? DamageDonePokemon { get; set; }

        [MaxLength(250, ErrorMessage = "Max length is 250 characters")]
        public string? PokeImagen { get; set; }

        [Required(ErrorMessage = "Capturado is required")]
        public bool Capturado { get; set; }

        [Required(ErrorMessage = "Shiny is required")]
        public bool Shiny { get; set; }
    }
}
