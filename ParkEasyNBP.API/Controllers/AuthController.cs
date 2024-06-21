using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParkEasyNBP.Application.DTOs;
//using ParkEasyNBP.Application.Models;
using ParkEasyNBP.Domain.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkEasyNBP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager; // Promenite ovde
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) // Promenite ovde
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CredentialModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                ApplicationUser user = new ApplicationUser // Promenite ovde
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName, // Ako imate dodatna svojstva
                    LastName = model.LastName,
                    Address = model.Address,
                    Phone = model.Phone
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return BadRequest(result.Errors.FirstOrDefault());

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }
                await userManager.AddToRoleAsync(user, "User");

                return Ok("Uspesna registracija!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register-controller")]
        public async Task<IActionResult> RegisterController(CredentialModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                ApplicationUser user = new ApplicationUser // Promenite ovde
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName, // Ako imate dodatna svojstva
                    LastName = model.LastName,
                    Address = model.Address,
                    Phone = model.Phone
                    
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return BadRequest(result.Errors.FirstOrDefault());

                if (!await roleManager.RoleExistsAsync("Controllor"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Controllor"));
                }
                await userManager.AddToRoleAsync(user, "Controllor");

                return Ok("Uspesna registracija!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound();

            if (await userManager.CheckPasswordAsync(user, model.Password))
            {
                // Generate JWT token
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq78fUjkyzfLz56gTq"));
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var userRoles = await userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                    audience: "https://localhost:5001/",
                    issuer: "https://localhost:5001/",
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

                var tokenKey = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(
                    new
                    {
                        token = tokenKey,
                        expiration = token.ValidTo
                    });
            }
            return Unauthorized("Wrong username or password");
        
    }

       
       
    }
}
