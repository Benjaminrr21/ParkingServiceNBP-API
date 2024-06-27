using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.Penalties
{
    public class NewPenaltyDTO
    {
        public string Why { get; set; }
       
        public decimal Price { get; set; }
       
        public DateTime DateTime { get; set; }

        public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }
    }
}
