using AutoMapper;
using DesignAPI.Models.DTOs.PujaDTO;
using DesignAPI.Models.Entity;
using DesignAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DesignAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CocheController : BaseController<CocheEntity, CocheDTO, CreateCocheDTO>
        {
            public CocheController(ICocheRepository CocheRepository,
                IMapper mapper, ILogger<CocheController> logger)
                : base(CocheRepository, mapper, logger)
            {

            }
        }
   }

