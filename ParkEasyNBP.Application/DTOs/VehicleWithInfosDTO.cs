using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Application.DTOs.Penalties;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class VehicleWithInfosDTO
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public serDTO User { get; set; }
        public ICollection<PenaltyOfVehicleDTO> Penalties { get; set; } = new List<PenaltyOfVehicleDTO>();
        public ICollection<OOCardOfVehicle> OneOffCards { get; set; }
        public ICollection<SCardOfVehicle> SubscriptionCards { get; set; }
    }
}
