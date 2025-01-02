using PokeAPI.Models.DTOs.UserDto;
using AutoMapper;
using PokeAPI.Models.DTOs;
using PokeAPI.Models.Entity;

namespace PokeAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
           // CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<Category, CreateCategoryDto>().ReverseMap();
           // CreateMap<LibroEntity, LibroDTO>().ReverseMap();
           // CreateMap<LibroEntity, CreateLibroDTO>().ReverseMap();
            //CreateMap<EditorialEntity, EditorialDTO>().ReverseMap();
            //CreateMap<EditorialEntity, CreateEditorialDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
