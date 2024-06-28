using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.ControlDTO
{
    public class NewControlDTO
    {
        public DateTime Time { get; set; } = DateTime.Now;
        public int VehicleId { get; set; }
        public int ControllorId { get; set; }
    }
}
