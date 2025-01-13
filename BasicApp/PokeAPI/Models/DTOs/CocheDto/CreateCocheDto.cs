using System.ComponentModel.DataAnnotations;

namespace BasicApi.Models.DTOs.CocheDto
{
    public class CreateCocheDto
    {
        [Required(ErrorMessage = "Marca is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Modelo is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Precio is required")]
        public float Precio { get; set; }
    }
}
