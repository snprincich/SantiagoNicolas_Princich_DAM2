namespace HousesAPI.Models.DTOs.HouseDTO
{
    public class HouseDTO : CreateHouseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
