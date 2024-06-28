using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class VehicleControlDTO
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Penalty> Penalties { get; set; } = new List<Penalty>();
        public ICollection<OneOffCard> OneOffCards { get; set; }
        public ICollection<SubscriptionCard> SubscriptionCards { get; set; }
    }
}
