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
        public int NumberOfPlaces { get; set; }
        public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; } = new List<ParkingPlace>();
        public ICollection<PublicGarage> PublicGarages { get; set; } = new List<PublicGarage>();


    }
}
