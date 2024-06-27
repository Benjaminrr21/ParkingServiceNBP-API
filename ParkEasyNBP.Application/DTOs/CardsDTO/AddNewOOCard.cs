using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs.CardsDTO
{
    public class AddNewOOCard
    {
        public string Code { get; set; }
        public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }
    }
}
