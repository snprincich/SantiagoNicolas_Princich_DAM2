using AutoMapper;
using DesignAPI.Models.DTOs.PujaDTO;
using DesignAPI.Models.Entity;
using DesignAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DesignAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PujaController : BaseController<PujaEntity, PujaDTO, CreatePujaDTO>
    {
        public PujaController(IPujaRepository PujaRepository,
            IMapper mapper, ILogger<PujaController> logger)
            : base(PujaRepository, mapper, logger)
        {

        }
    }
}