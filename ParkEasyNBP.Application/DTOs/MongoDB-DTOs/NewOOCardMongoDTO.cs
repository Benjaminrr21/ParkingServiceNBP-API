using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.MongoDB_DTOs
{
    public class NewOOCardMongoDTO
    {
        public string Code { get; set; }
        public DateTime DateTimeSelling { get; set; }
        public DateTime Period { get; set; }
        public string VehicleId { get; set; }
    }
}
