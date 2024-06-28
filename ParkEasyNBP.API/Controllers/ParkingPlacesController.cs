using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.API.Mediator.Query;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.API.FilteringSortingPaging;
using System.Linq.Expressions;

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
        public async Task<IActionResult> GetParkingPlaces([FromQuery]ParkingPlaceQueryObject queryObject)
        {
            Dictionary<string, Expression<Func<ParkingPlace, object>>> columnMaps = new Dictionary<string, Expression<Func<ParkingPlace, object>>>
            {

                /*["Status"] = p => p.Status,
                ["Street"] = p => p.Street,*/
                ["PID"] = p => p.Id
            };

            var parkingSpaces = await service.GetAll();

            if (!string.IsNullOrEmpty(queryObject.Status))
                parkingSpaces = parkingSpaces.Where(p => p.Status == queryObject.Status).AsQueryable();

            parkingSpaces = parkingSpaces.AsQueryable().ApplySorting(queryObject, columnMaps);
            parkingSpaces = parkingSpaces.AsQueryable().ApplyPaging(queryObject);

            var result = new ResultQuery<ParkingPlaceGetDTO>
            {
                Total = parkingSpaces.Count(),
                Items = parkingSpaces.Select(p => new ParkingPlaceGetDTO
                {
                    Id = p.Id,
                    Street = p.Street,
                    ZoneId = p.ZoneId,
                    Status = p.Status,
                    //Id = p.Id
                }).ToList()
            };

            return Ok(parkingSpaces);
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

        [HttpPut("reserve/{vid}/{pid}")]
        public async Task<IActionResult> Reserve([FromRoute]int vid, [FromRoute]int pid)
        {
            
            return Ok(await service.ReservePlace(vid, pid));
        }
        [HttpPut("free/{vid}/{pid}")]
        public async Task<IActionResult> Free([FromRoute] int vid, [FromRoute] int pid)
        {
            return Ok(await service.FreePlace(vid, pid));
        }
    }
}
