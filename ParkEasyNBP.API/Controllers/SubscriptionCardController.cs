using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionCardController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SubscriptionCardController(IUnitOfWork uow,IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
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
                return Ok(card);
            }
            return NotFound("Nepostojeci objekat.");
        }

    }
}
