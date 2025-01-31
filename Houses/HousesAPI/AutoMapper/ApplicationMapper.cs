using HousesAPI.Models.DTOs.UserDto;
using AutoMapper;
using HousesAPI.Models.DTOs;
using HousesAPI.Models.Entity;
using HousesAPI.Models.DTOs.HouseDTO;

namespace HousesAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<HouseEntity, HouseDTO>().ReverseMap();
            CreateMap<HouseEntity, CreateHouseDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
