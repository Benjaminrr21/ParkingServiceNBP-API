using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionCardController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IMongoRepository<MongoSubscriptionCard> mongo;

        public SubscriptionCardController(IUnitOfWork uow,IMapper mapper,IMongoRepository<MongoSubscriptionCard> mongo)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mongo = mongo;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCards()
        {
           
            return Ok(await uow.SubscriptionCardRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]NewSCard card)
        {
            return Ok(await uow.SubscriptionCardRepository.Create(mapper.Map<SubscriptionCard>(card)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var card = await uow.SubscriptionCardRepository.Delete(id);
            if(card != null)
            {
                return Ok(new Result<SubscriptionCard>
                {
                    Data = card
                });
            }
            return NotFound(new Result<SubscriptionCard>
            {
                Errors = new List<string> { "Nepostojeci objekat."}
            });
        }

    }
}
