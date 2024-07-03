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



        public ZoneController( IMongoRepository<MongoZone> mongo, IZoneRepository service, IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork)
        {
            this.mongo = mongo;
            this.service = service;
            this.mapper = mapper;
            _mediator = mediator;
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllZones(/*[FromQuery]ZoneQueryObject qo*/)
        {

            /*var list = await service.GetAll();
            var list2 = mapper.Map<IEnumerable<ZonesDTO>>(list);
            return Ok(list2);*/
            //var list = await _mediator.Send(new GetAllZonesQuery());
            // return Ok(mongoService.GetAll());
            //return Ok(await zonesGraph.GetAll());

            /*  var list = await service.GetAll();
              var list2 = mapper.Map<IEnumerable<ZonesDTO>>(list);

              Dictionary<string, Expression<Func<ZonesDTO, object>>> columnMaps = new Dictionary<string, Expression<Func<ZonesDTO, object>>>
              {
                  ["Name"] = c => c.Name
              };
              if (!qo.Name.IsNullOrEmpty())
                  list2 = list2.Where(c => c.Name == qo.Name).AsQueryable();*/

            //list2 = list2.AsQueryable();/*ApplySorting<ZonesDTO>(qo, columnMaps).ApplyPaging(qo);*/
            //return Ok(mongoService.GetAll());
            var list = await service.GetAll();
            var list2 = mapper.Map<IEnumerable<ZonesDTO>>(list);
            return Ok(list2);
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var obj = await service.Get(id);
            if (obj == null)
            {
                throw new EntityNullException();
            }
            return Ok(mapper.Map<ZonesDTO>(obj));
            /*var zone = await _mediator.Send(new GetZoneByIdQuery(id));
            if (zone == null)
            {
                return NotFound("Nije pronađena zona.");
            }
            return Ok(zone);*/
        }
        [HttpPost]
        public async Task<IActionResult> AddZone([FromBody] ZoneCreateDTO zone)
        {
            //throw new NotImplementedException();
            var z = mapper.Map<Zone>(zone);
            return Ok(await unitOfWork.ZoneRepository.Create(z)/*await zonesGraph.Create(z)*/);
            /*var zona = mapper.Map<Domain.Models.Zone>(zone);
            await service.Create(zona);
            return Ok(zona);*/
           // var createdZone = await _mediator.Send(new AddZoneCommand(zone));
            //return Ok(createdZone);
            /*  var zona = mapper.Map<Domain.Models.Zone>(zone);
              await service.Create(zona);*/
            //var zona = await mongoService.Create(mapper.Map<ZoneMongoDB>(zone));
          
            //return Ok(zona);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone([FromRoute]int id)
        {
            var response = await service.Delete(id);
            return Ok(response);
            /*var response = await _mediator.Send(new DeleteZoneCommand(id));
            return Ok(response);*/
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
    }
}
