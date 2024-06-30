using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class ParkingPlaceCreateSimple
    {
        public string Status { get; set; }
        public string Street { get; set; }
        public int ZoneId { get; set; }
    }
}
