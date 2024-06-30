using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class Penalty
    {
        public int Id { get; set; }
        public string Why {  get; set; }
        public bool IsPay { get; set; } = false;
        public decimal Price { get; set; }
        public string? Reason { get; set; }
        public DateTime DateTime { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }


    }
}
