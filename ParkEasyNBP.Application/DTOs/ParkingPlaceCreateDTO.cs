using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class ParkingPlaceCreateDTO
    {
        public string Status { get; set; }
        public string Street { get; set; }
        public int ZoneId { get; set; }
        public int? PublicGarageId { get; set; }
        public bool? IsUnderground { get; set; } // Može biti null
        public int? GarageLevel { get; set; } // Može biti null
    }
}
