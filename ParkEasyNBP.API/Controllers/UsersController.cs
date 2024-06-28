using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using AutoMapper;
using ParkEasyNBP.Application.DTOs;


namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper mapper;

        public UsersController(IUserRepository service, UserManager<ApplicationUser> userManager,IMapper mapper)
        {
            this.service = service;
            _userManager = userManager;
            this.mapper = mapper;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            return Ok(await service.GetById(id));
        }
    }
}
