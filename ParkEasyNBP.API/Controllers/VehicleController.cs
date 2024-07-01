using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.DTOs.MongoDB_DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository service;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        private readonly IMongoRepository<MongoVehicle> mongorepo;

        public VehicleController(IVehicleRepository service, IMapper mapper, IUnitOfWork uow, IMongoRepository<MongoVehicle> mongorepo)
        {
            this.service = service;
            this.mapper = mapper;
            this.uow = uow;
            this.mongorepo = mongorepo;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            /* var list = await service.GetAll();
             var list2 = mapper.Map<IEnumerable<VehicleWithInfosDTO>>(list);
             return Ok(list2);*/
            return Ok(await mongorepo.GetAll());

            // return Ok(mapper.Map<IEnumerable<VehicleWithPaymentsDTO>>(await service.GetAll()));  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(mapper.Map<VehicleWithInfosDTO>(await service.Get(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] /*NewVehicleDTO*/ NewVehicleMongo v)
        {
            //SQL SERVER
            /*
            var vehicle = mapper.Map<Vehicle>(v);
            return Ok(await service.Create(vehicle));
            */
            return Ok(await mongorepo.Create(mapper.Map<MongoVehicle>(v)));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] VehicleUpdateDTO v)
        {
            var p = mapper.Map<Vehicle>(v);
            p.Id = id;

            if (p == null || p.Id != id)
            {
                return BadRequest();
            }

            var updatedZone = await service.Update(id, p);
            if (updatedZone == null)
            {
                return NotFound();
            }

            return Ok(updatedZone);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var obj = await service.Delete(id);
            if (obj == null)
            {
                return NotFound("Ne postoji");
            }
            return Ok(obj);
        }
        [HttpGet("/vehicleof/{id}")]
        public async Task<IActionResult> getVehicleOfOwner([FromRoute]string id)
        {
            return Ok(await service.VehicleOfOwner(id));
        }
    }

    
}
