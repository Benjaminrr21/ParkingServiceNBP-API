using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository service;
        public VehicleController(IVehicleRepository service)
        {
            this.service = service; 
        }
        [HttpGet]
        public async Task<IActionResult> getAll() 
        { 
            return Ok(await service.GetAll());  
        }


    }
}
