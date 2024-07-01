using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using ParkEasyNBP.Infrastructure.MongoDB;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneOffCardController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IMongoRepository<MongoOneOffCard> mongo;

        public OneOffCardController(IUnitOfWork uow, IMapper mapper,IMongoRepository<MongoOneOffCard> mongo)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.mongo = mongo;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCards()
        {
            return Ok(await uow.OneOffCardRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] AddNewOOCard card)
        {
            var c = mapper.Map<OneOffCard>(card);
            return Ok(await uow.OneOffCardRepository.Create(c));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var card = await uow.OneOffCardRepository.Delete(id);
            if (card != null)
            {
                return Ok(card);
            }
            return NotFound("Nepostojeci objekat.");
        }
    }
}
