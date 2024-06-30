using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Application.DTOs.ControlDTO;
using ParkEasyNBP.Domain.Interfaces;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlController : ControllerBase
    {
        private readonly IControlRepository control;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ControlController(IUnitOfWork unitOfWork, IControlRepository control, IMapper mapper)
        {
            this.control = control;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ControlDTO controlDTO)
        {
            return Ok(mapper.Map<IEnumerable<ControlDTO>>(await control.GetAll()));
        }
    }
}
