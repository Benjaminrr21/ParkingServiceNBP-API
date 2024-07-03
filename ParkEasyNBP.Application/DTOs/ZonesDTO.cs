using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class ZonesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlaces { get; set; }
        public ICollection<ParkingPlaceGetDTO> ParkingPlaces { get; set; } = new List<ParkingPlaceGetDTO>();
        public ICollection<PublicGarageGetDTO> PublicGarages { get; set; } = new List<PublicGarageGetDTO>();
    }
}
