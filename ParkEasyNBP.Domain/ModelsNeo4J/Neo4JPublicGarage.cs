using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsNeo4J
{
    public class Neo4JPublicGarage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfPlaces { get; set; }
        public int NumberOfFreePlaces { get; set; }
        public string WorkingTime { get; set; }
        //public ICollection<ParkingPlace> ParkingPlaces { get; set; }
        //public Zone Zone { get; set; }
        public int ZoneId { get; set; }
    }
}
