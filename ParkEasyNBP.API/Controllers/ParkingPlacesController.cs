using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.API.Mediator.Query;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.API.FilteringSortingPaging;
using System.Linq.Expressions;
using ParkEasyNBP.Infrastructure.MongoDB;
using ParkEasyNBP.Application.DTOs.MongoDB_DTOs;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.API.Mediator.Command;
using MediatR;
using ParkEasyNBP.Domain.Models.Results;
using ParkEasyNBP.Domain.Exceptions;
using ParkEasyNBP.Infrastructure.Neo4j.Services;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingPlacesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ParkingsPlacesServices serviceNeo;
        private readonly IMongoRepository<MongoParkingPlace> mongo;
        private readonly IMediator mediator;
        private readonly IParkingPlaceRepository service;
        private readonly IMapper mapper;

        public ParkingPlacesController(IUnitOfWork unitOfWork,IMongoRepository<MongoParkingPlace> mongo, ParkingsPlacesServices serviceNeo, IMediator mediator, IParkingPlaceRepository service, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.serviceNeo = serviceNeo;
            this.mongo = mongo;
            this.mediator = mediator;
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetParkingPlaces(/*[FromQuery] ParkingPlaceQueryObject queryObject*/)
        {
           /*  Dictionary<string, Expression<Func<ParkingPlace, object>>> columnMaps = new Dictionary<string, Expression<Func<ParkingPlace, object>>>
             {
                 ["Status"] = p => p.Status,
                 ["ZoneId"] = p => p.ZoneId,
                 ["Street"] = p => p.Street // Dodato za sortiranje po ulici
             };

             var parkingSpaces = await service.GetAll();
             var listq = parkingSpaces.AsQueryable();

             if (!string.IsNullOrEmpty(queryObject.Status))
                 listq = listq.Where(p => p.Status == queryObject.Status);

             // Sortiranje
             listq = listq.ApplySorting(queryObject, columnMaps);
             listq = listq.ApplyPaging(queryObject);

   
             var result = new ResultQuery<ParkingPlaceGetDTO>
             {
                 Total = listq.Count(),
                 Items = listq.Select(p => new ParkingPlaceGetDTO
                 {
                     Id = p.Id,
                     Street = p.Street,
                     ZoneId = p.ZoneId,
                     Status = p.Status
                 }).ToList()
             };
           */
            var result = await service.GetAll();

            //NEO4j
            //var result = await serviceNeo.GetAll();

            //MONGO
            //var resultMongo = await mongo.GetAll();

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            //MEDIATOR
            var res = await mediator.Send(new ParkingPlaceIdQuery(id));
            if (!res.IsSuccess)
                return BadRequest(res.Errors);
            return Ok(res.Data);

            //  MONGO
            //var resMongo = await mongo.GetById(id)
        }
        [HttpPost]
        public async Task<IActionResult> AddParkingPlace([FromBody] ParkingPlaceCreateSimple place/*CreateParkingPlaceCommand parkingplace*/ /*MongoParkingPlace parkingplace*/)
        {
            //MONGO
            //return Ok(await mongo.Create(parkingplace));

            //SQL
            /*var res = await mediator.Send(parkingplace);
            if (!res.IsSuccess)
            {
                return BadRequest(res.Errors);
            }
            return Ok(res.Data);
            //var pp = mapper.Map<ParkingPlaceMongoDB>(CreatePa);
            //await unitOfWork.ParkingPlaceRepository.Create(pp);
            //return Ok(await serviceMongoDB.Create(pp));*/

            //NEO4j
            var p = await serviceNeo.Create(mapper.Map<ParkingPlace>(place));
            return Ok(p);
        }
        [HttpPost("with-garage")]
        public async Task<IActionResult> AddParkingPlaceWithGarage([FromBody] ParkingPlaceCreateDTO parkingplace)
        {
            return Ok(await service.AddPlaceWithGarage(mapper.Map<ParkingPlace>(parkingplace)));
        }
        /* public async Task<IActionResult> AddParkingPlace(ParkingPlaceCreateDTO parkingPlace)
         {
             var pp = mapper.Map<ParkingPlace>(parkingPlace);
             await unitOfWork.ParkingPlaceRepository.Create(pp);
             return Ok(pp);
         }*/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(/*[FromRoute] int id*/[FromBody]DeleteParkingPlaceCommand command)
        {
            //SQL - MEDIATOR
            var obj = await mediator.Send(command);
            if(!obj.IsSuccess) 
                return BadRequest(obj.Errors);
            return Ok(obj.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlace(/*[FromRoute]int id, [FromBody]ParkingPlaceUpdateDTO place*/[FromBody]UpdateParkingPlaceCommand cmd)
        {
            var p = await mediator.Send(cmd);
            if(!p.IsSuccess) return BadRequest(p.Errors);
            return Ok(p.Data);
         
        }

        [HttpPut("reserve/{vid}/{pid}")]
        public async Task<IActionResult> Reserve([FromRoute]int vid, [FromRoute]int pid)
        {

            var res = await service.ReservePlace(vid, pid);
            if (res != null)
            {
                return Ok(await service.ReservePlace(vid, pid));
            }

            return BadRequest(new Result<ParkingPlace>
            {
                IsSuccess = false,
                Errors = new List<string>
                {
                 new CantReserveWithouCardException().Message
                }
            }) ;
        }
        [HttpPut("free/{vid}/{pid}")]
        public async Task<IActionResult> Free([FromRoute] int vid, [FromRoute] int pid)
        {
            return Ok(await service.FreePlace(vid, pid));
        }
    }
}
