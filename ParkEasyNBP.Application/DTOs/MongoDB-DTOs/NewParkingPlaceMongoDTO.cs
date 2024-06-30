using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.MongoDB_DTOs
{
    public class NewParkingPlaceMongoDTO
    {
        public string Status { get; set; } = "Free";
        public string Street { get; set; }
    }
}
