using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.DTOs.PujaDTO
{
    public class CreatePujaDTO
    {
        [Required(ErrorMessage = "PujaActual is required")]
        public double PujaActual { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Id_coche is required")]
        public int Id_coche { get; set; }
    }
}
