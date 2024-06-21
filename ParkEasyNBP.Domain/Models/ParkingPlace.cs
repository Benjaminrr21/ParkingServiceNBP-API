using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class ParkingPlace
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Street { get; set; }
        public int? PublicGarageId { get; set; } // Može biti null
        public PublicGarage PublicGarage { get; set; }

        public bool? IsUnderground { get; set; } // Može biti null
        public int? GarageLevel { get; set; } // Može biti null

    }
}
