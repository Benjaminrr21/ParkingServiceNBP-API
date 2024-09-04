using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Application.DTOs.MongoDB_DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneOffCardController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IMongoRepository<MongoOneOffCard> mongo;

        public OneOffCardController(IUnitOfWork uow, IMediator mediator, IMapper mapper,IMongoRepository<MongoOneOffCard> mongo)
        {
            this.uow = uow;
            this.mediator = mediator;
            this.mapper = mapper;
            this.mongo = mongo;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCards()
        {
            //SQL SERVER 
            return Ok(await uow.OneOffCardRepository.GetAll());

            //MONGO
            //return Ok(await mongo.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] CreateOneOffCardCommand command /*AddNewOOCard /*[FromBody]NewOOCardMongoDTO*/ /*card*/)
        {
            //SQL SERVER
            /*var c = mapper.Map<OneOffCard>(card);
            return Ok(await uow.OneOffCardRepository.Create(c));*/
            var oocard = await mediator.Send(command);
            if (!oocard.IsSuccess) return BadRequest(oocard.Errors);
            return Ok(oocard.Data);

            //MONGO
           /* var c = mapper.Map<MongoOneOffCard>(card);
            return Ok(await mongo.Create(c));*/
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            //SQL
             var card = await uow.OneOffCardRepository.Delete(id);
             if (card != null)
             {
                 return Ok(new Result<OneOffCard>
                 {
                     Data = card,
                 });
             }
             return NotFound(new Result<OneOffCard>
             {
                 Errors = new List<string> { "Nepostojeci objekat."}
             });

            //MONGO
            //return Ok(await mongo.Delete(id));
        }
    }
}
