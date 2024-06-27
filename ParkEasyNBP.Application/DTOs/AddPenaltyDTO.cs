using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class AddPenaltyDTO
    {
        public string Reason { get; set; }
        public DateTime DateTime { get; set; }

        public int VehicleId { get; set; }
    }
}
