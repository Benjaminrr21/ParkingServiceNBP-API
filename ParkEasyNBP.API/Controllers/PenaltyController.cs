using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.API.FilteringSortingPaging;
using ParkEasyNBP.API.Mediator.Query;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.DTOs.Penalties;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;
using Repository;
using System.Linq.Expressions;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IMongoRepository<MongoPenalty> mongo;
        private readonly IUnitOfWork unitOfWork;

        public PenaltyController(IUnitOfWork unitOfWork, IUnitOfWork uow, IMapper mapper,IMongoRepository<MongoPenalty> mongo)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mongo = mongo;
            this.unitOfWork = unitOfWork; 
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]PenaltyQueryObject queryObject)
        {
            Dictionary<string, Expression<Func<Penalty, object>>> columnMaps = new Dictionary<string, Expression<Func<Penalty, object>>>
            {
                ["Price"] = p => p.Price,
            };

             var penalties = await uow.PenaltyRepository.GetAll();
             var listq = penalties.AsQueryable();


             // Sortiranje
             listq = listq.ApplySorting(queryObject, columnMaps);
             listq = listq.ApplyPaging(queryObject);

   
             var result = new ResultQuery<Penalty>
             {
                 Total = listq.Count(),
                 Items = listq.Select(p => new Penalty
                 {
                     Id = p.Id,
                     Price = p.Price
                 }).ToList()
             };
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPenaltyToVehicle([FromBody]NewPenaltyDTO addPenalty)
        {
            return Ok(await uow.PenaltyRepository.Create(mapper.Map<Penalty>(addPenalty)));
        }

        [HttpPost("/removing/{id}/{reason}")]
        public async Task<IActionResult> RemovePenalty([FromRoute] int id, string reason)
        {
            /*var obj = await uow.Get(id);
            obj.Reason = reason;*/
            return Ok(await uow.PenaltyRepository.RemovePenalty(id,reason));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            return Ok(await uow.PenaltyRepository.Delete(id));
        }
        [HttpGet("/myPenalties/{vid}")]
        public async Task<IActionResult> GetMyPenalties([FromRoute] int vid)
        {
            return Ok(await uow.PenaltyRepository.GetPenaltiesOfVehicle(vid));
        }

    }
}
