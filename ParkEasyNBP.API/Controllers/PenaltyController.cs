using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.DTOs.Penalties;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using Repository;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        private readonly IPenaltyRepository repository;
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork;

        public PenaltyController(UnitOfWork unitOfWork, IPenaltyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork; 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddPenaltyToVehicle([FromBody]NewPenaltyDTO addPenalty)
        {
            return Ok(await repository.Create(mapper.Map<Penalty>(addPenalty)));
        }

        [HttpPost("/removing/{id}/{reason}")]
        public async Task<IActionResult> RemovePenalty([FromRoute] int id, string reason)
        {
            /*var obj = await repository.Get(id);
            obj.Reason = reason;*/
            return Ok(await repository.RemovePenalty(id,reason));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            return Ok(await repository.Delete(id));
        }

    }
}
