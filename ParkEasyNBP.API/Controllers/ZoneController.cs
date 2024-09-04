using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParkEasyNBP.API.FilteringSortingPaging;
using ParkEasyNBP.API.Mediator.Query;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;
using Repository.Repositories;
using System.Linq.Expressions;
//using System.Security.Policy;
using MediatR;
using ParkEasyNBP.Application.Requests.Zones;
using Repository.Neo4jRepositories;
using ParkEasyNBP.Infrastructure.Neo4j.Services;
using ParkEasyNBP.Domain.Exceptions;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Domain.ModelsNeo4J;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IMongoRepository<MongoZone> mongo;
        private readonly IZoneRepository service;
        private readonly IMapper mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork unitOfWork;
        private readonly ZonesService serviceNeo;

        public ZoneController( IMongoRepository<MongoZone> mongo, IZoneRepository service, IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork, ZonesService serviceNeo)
        {
            this.mongo = mongo;
            this.service = service;
            this.mapper = mapper;
            _mediator = mediator;
            this.unitOfWork = unitOfWork;
            this.serviceNeo = serviceNeo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllZones(/*[FromQuery]ZoneQueryObject qo*/)
        {
            //SQL
            //var list = mapper.Map<IEnumerable<ZonesDTO>>(await service.GetAll());
            //var list = await _mediator.Send(new GetAllZonesQuery());
            //var list2 = mapper.Map<IEnumerable<ZonesDTO>>(list);
            
            //MONGO
            //var listMongo = await mongo.GetAll();

            //NEO4J
            var list3 = await serviceNeo.GetAll();
            return Ok(mapper.Map<IEnumerable<Neo4jZone>>(list3));
            // return Ok(list);
            //return Ok(listMongo);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetZoneByIdQuery query /*int id*/)
        {
           /* var obj = await service.Get(id);
            if (obj == null)
            {
                throw new EntityNullException();
            }
            return Ok(mapper.Map<ZonesDTO>(obj));*/
           
            var zone = await _mediator.Send(query);
            if (zone == null)
            {
                return NotFound("Nije pronađena zona.");
            }
            return Ok(zone);
        }
        [HttpPost]
        public async Task<IActionResult> AddZone([FromBody] ZoneCreateDTO/* CreateZoneCommand*/ zone)
        {
            var z = mapper.Map<Zone>(zone);

            //NEO4j
            return Ok(await serviceNeo.Create(z));


            //SQL
            //return Ok(await unitOfWork.ZoneRepository.Create(z));
            /* var createdZone = await _mediator.Send(zone);
            if (createdZone.IsSuccess)
            {
                return Ok(createdZone.Data);
            }

            return BadRequest(createdZone.Errors);*/
           
            //MONGO
            //var zona = await mongoService.Create(mapper.Map<ZoneMongoDB>(zone));
            //return Ok(zona);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone([FromRoute]int id)
        {
            //SQL
            var response = await service.Delete(id);
            //return Ok(response);
            /*var response = await _mediator.Send(new DeleteZoneCommand(id));
            return Ok(response);*/

            //NEO4j
            return Ok(await serviceNeo.Delete(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateZone(int id, [FromBody] ZoneCreateDTO zonee)
        {
            var zone = mapper.Map<Zone>(zonee);
            zone.Id = id;

            if (zone == null || zone.Id != id)
            {
                return BadRequest();
            }

            var updatedZone = await service.Update(id, zone);
            if (updatedZone == null)
            {
                return NotFound();
            }

            return Ok(updatedZone);
          /*  var updatedZone = await _mediator.Send(new UpdateZoneCommand(id, zonee));
            if (updatedZone == null)
            {
                return NotFound();
            }
            return Ok(updatedZone);*/
        }

        //NEO4j
        [HttpGet("{zid}/contains/{pid}")]
        public async Task<IActionResult> ZoneContainsParkingPlace(int zid, int pid)
        {
            await serviceNeo.ZoneContainsParkingPlace(zid, pid);
            return Ok();
        }
    }
}
