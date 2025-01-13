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
        public CocheController(ICocheRepository CocheRepository,
            IMapper mapper, ILogger<CocheController> logger)
            : base(CocheRepository, mapper, logger)
        {

        }
    }
}
