using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs.ControlDTO;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlController : ControllerBase
    {
        private readonly IControlRepository control;
        private readonly IMapper mapper;
        private readonly IMongoRepository<MongoControl> mongo;
        private readonly IUnitOfWork unitOfWork;

        public ControlController(IUnitOfWork unitOfWork, IControlRepository control, IMapper mapper,IMongoRepository<MongoControl> mongo)
        {
            this.control = control;
            this.mapper = mapper;
            this.mongo = mongo;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ControlDTO controlDTO /*MongoControl control*/)
        {
            ///SQL
            return Ok(await control.Createe(mapper.Map<Control>(controlDTO)));
            //MONGODB
           // return Ok(mongo.Create(control));
        }
    }
}
