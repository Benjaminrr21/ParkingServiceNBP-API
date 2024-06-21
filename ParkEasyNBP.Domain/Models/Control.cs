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
        public int RegNumberOfVehicle { get; set; }
    }
}
