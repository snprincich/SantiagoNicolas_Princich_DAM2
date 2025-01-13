using BasicApi.Models.DTOs.UserDto;
using AutoMapper;
using BasicApi.Models.DTOs;
using BasicApi.Models.Entity;
using BasicApi.Models.DTOs.CocheDto;

namespace BasicApi.AutoMapper
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
            CreateMap<CocheEntity, CocheDto>().ReverseMap();
            CreateMap<CocheEntity, CreateCocheDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            
        }
    }
}
