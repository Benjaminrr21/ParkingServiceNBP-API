using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.ControlDTO
{
    public class ControlDTO
    {
        public DateTime Time { get; set; }
        public bool IsPenalty { get; set; }
        public int VehicleId { get; set; }
        //public VehicleControlDTO Vehicle { get; set; }
        public string ControllorId { get; set; }
        //public ControllorDTO Controllor { get; set; }
    }
}
