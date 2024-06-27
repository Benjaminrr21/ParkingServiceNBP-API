using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class OwnerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int VehicleId { get; set; }
        public VehicleOfOwnerDTO Vehicle { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
