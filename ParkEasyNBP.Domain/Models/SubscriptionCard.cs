using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class SubscriptionCard
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Period { get; set; }
        //public int RegisterNumber { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
