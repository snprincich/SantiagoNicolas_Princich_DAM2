using AutoMapper;
using BasicApi.Models.DTOs.CocheDto;
using BasicApi.Models.Entity;
using BasicApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocheController : BaseController<CocheEntity, CocheDto, CreateCocheDto>
    {
        public CocheController(ICocheRepository cocheRepository,
            IMapper mapper, ILogger<ICocheRepository> logger)
            : base(cocheRepository, mapper, logger)
        {

        }
    }
}
