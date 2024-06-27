using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
       


    }
}
