using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class Control
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsPenalty { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string ControllorId { get; set; }
      //  public ApplicationUser Controllor { get; set; }
    }
}
