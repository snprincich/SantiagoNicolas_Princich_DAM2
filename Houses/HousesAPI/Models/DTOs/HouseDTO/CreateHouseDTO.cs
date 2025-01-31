using System.ComponentModel.DataAnnotations;

namespace HousesAPI.Models.DTOs.HouseDTO
{
    public class CreateHouseDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "AvailableUnits is required")]
        public int AvailableUnits { get; set; }

        [Required(ErrorMessage = "Wifi is required")]
        public bool Wifi { get; set; }

        [Required(ErrorMessage = "Laundry is required")]
        public bool Laundry { get; set; }
    }
}
