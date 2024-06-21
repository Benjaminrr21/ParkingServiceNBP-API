using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public ICollection<ParkingPlace> ParkingPlaces { get; set; }
        public ICollection<PublicGarage> PublicGarages { get; set; }


    }
}
