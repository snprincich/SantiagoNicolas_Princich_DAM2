using AutoMapper;
using HousesAPI.Models.DTOs.HouseDTO;
using HousesAPI.Models.Entity;
using HousesAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HousesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : BaseController<HouseEntity, HouseDTO, CreateHouseDTO>
    {
        public HouseController(IHouseRepository HouseRepository,
            IMapper mapper, ILogger<HouseController> logger)
            : base(HouseRepository, mapper, logger)
        {

        }
    }
}
