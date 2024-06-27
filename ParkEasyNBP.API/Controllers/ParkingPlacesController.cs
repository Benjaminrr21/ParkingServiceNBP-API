using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingPlacesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IParkingPlaceRepository service;
        private readonly IMapper mapper;

        public ParkingPlacesController(IUnitOfWork unitOfWork, IParkingPlaceRepository service, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await unitOfWork.ParkingPlaceRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var obj = await service.Get(id);
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound("Nije pronadjeno parking mesto.");
        }
        [HttpPost]
        public async Task<IActionResult> AddParkingPlace(ParkingPlaceCreateDTO parkingPlace)
        {
            var pp = mapper.Map<ParkingPlace>(parkingPlace);
            await unitOfWork.ParkingPlaceRepository.Create(pp);
            return Ok(pp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var obj = await service.Delete(id);
            if (obj != null)
            {
                return Ok("Uspesno brisanje.");
            }
            return BadRequest("Nepostojece parking mesto.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlace([FromRoute]int id, [FromBody]ParkingPlaceUpdateDTO place)
        {
            var p = mapper.Map<ParkingPlace>(place);
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
    }
}
