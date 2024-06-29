using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using Repository.Repositories;
//using System.Security.Policy;
using MediatR;
using ParkEasyNBP.Application.Requests.Zones;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository service;
        private readonly IMapper mapper;
        private readonly IMediator _mediator;

        public ZoneController(IZoneRepository service, IMapper mapper, IMediator mediator)
        {
            this.service = service;
            this.mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllZones()
        {

            /*var list = await service.GetAll();
            var list2 = mapper.Map<IEnumerable<ZonesDTO>>(list);
            return Ok(list2);*/
            var list = await _mediator.Send(new GetAllZonesQuery());
            return Ok(list);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            /*var obj = await service.Get(id);
            if (obj == null)
            {
                return NotFound("Nije pronadjena zona.");
            }
            return Ok(obj);*/
            var zone = await _mediator.Send(new GetZoneByIdQuery(id));
            if (zone == null)
            {
                return NotFound("Nije pronađena zona.");
            }
            return Ok(zone);
        }
        [HttpPost]
        public async Task<IActionResult> AddZone([FromBody] ZoneCreateDTO zone)
        {
            /*var zona = mapper.Map<Domain.Models.Zone>(zone);
            await service.Create(zona);
            return Ok(zona);*/
            var createdZone = await _mediator.Send(new AddZoneCommand(zone));
            return Ok(createdZone);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone([FromRoute]int id)
        {
            /*var response = await service.Delete(id);
            return Ok(response);*/
            var response = await _mediator.Send(new DeleteZoneCommand(id));
            return Ok(response);
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

            /*var updatedZone = await service.Update(id, zone);
            if (updatedZone == null)
            {
                return NotFound();
            }

            return Ok(updatedZone);*/
            var updatedZone = await _mediator.Send(new UpdateZoneCommand(id, zonee));
            if (updatedZone == null)
            {
                return NotFound();
            }
            return Ok(updatedZone);
        }
    }
}
