using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using Repository.Repositories;
//using System.Security.Policy;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository service;
        private readonly IMapper mapper;

        public ZoneController(IZoneRepository service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllZones()
        {
            return Ok(await service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var obj = await service.Get(id);
            if(obj == null)
            {
                return NotFound("Nije pronadjena zona.");
            }
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddZone([FromBody] ZoneCreateDTO zone)
        {
            var zona = mapper.Map<Domain.Models.Zone>(zone);
            await service.Create(zona);
            return Ok(zona);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone([FromRoute]int id)
        {
            var response = await service.Delete(id);
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

            var updatedZone = await service.Update(id, zone);
            if (updatedZone == null)
            {
                return NotFound();
            }

            return Ok(updatedZone);
        }
    }
}
