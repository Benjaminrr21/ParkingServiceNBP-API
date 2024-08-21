using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email {  get; set; }
        public string Address { get; set; }
       /// <summary>
       /// public string Username { get; set; }
       /// </summary>
        //public string Password { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// public int? VehicleId { get; set; }
        /// </summary>
        public Vehicle? Vehicle { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        public ICollection<Control> Controls { get; set; }




    }
}
