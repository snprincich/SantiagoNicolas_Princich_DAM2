using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.DTOs.PujaDTO
{
    public class CreateCocheDTO
    {
        [Required(ErrorMessage = "Periodo is required")]
        public int Periodo { get; set; }

        [Required(ErrorMessage = "Modelo is required")]
        [MaxLength(50, ErrorMessage = "Max length is 100 characters")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Notas is required")]
        public string Notas {  get; set; }

        [Required(ErrorMessage = "Firma is required")]
        public string Firma { get; set; }

        [Required(ErrorMessage = "Imagen is required")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "PujaInicial is required")]
        public double PujaInicial { get; set; }
    }
}
