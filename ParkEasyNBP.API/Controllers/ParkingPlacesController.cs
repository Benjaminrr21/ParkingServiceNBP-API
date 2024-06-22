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
        [HttpPost]
        public async Task<IActionResult> AddParkingPlace(ParkingPlaceCreateDTO parkingPlace)
        {
            var pp = mapper.Map<ParkingPlace>(parkingPlace);
            await unitOfWork.ParkingPlaceRepository.Create(pp);
            return Ok(pp);
        }
    }
}
