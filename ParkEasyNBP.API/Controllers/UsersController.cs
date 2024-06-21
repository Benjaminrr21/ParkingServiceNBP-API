using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;


namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository service;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUserRepository service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            _userManager = userManager;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await service.GetAll());
        }
        [HttpGet("get-all-controllors")]
        public async Task<IActionResult> GetAllControllors()
        {
            return Ok(await service.GetAllControllors());
        }
    }
}
