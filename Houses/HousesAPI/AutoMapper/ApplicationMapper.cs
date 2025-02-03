using DesignAPI.Models.DTOs.UserDto;
using AutoMapper;
using DesignAPI.Models.DTOs;
using DesignAPI.Models.Entity;
using DesignAPI.Models.DTOs.PujaDTO;

namespace DesignAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<PujaEntity, PujaDTO>().ReverseMap();
            CreateMap<PujaEntity, CreatePujaDTO>().ReverseMap();

            CreateMap<CocheEntity, CocheDTO>().ReverseMap();
            CreateMap<CocheEntity, CreateCocheDTO>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
