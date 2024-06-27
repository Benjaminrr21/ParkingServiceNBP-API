using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.CardsDTO
{
    public class SCardOfVehicle
    {
        public string Code { get; set; }
        public DateTime Period { get; set; }
        //public int RegisterNumber { get; set; }
        public int VehicleId { get; set; }
        //public VehicleOfCardDTO Vehicle { get; set; }
    }
}
