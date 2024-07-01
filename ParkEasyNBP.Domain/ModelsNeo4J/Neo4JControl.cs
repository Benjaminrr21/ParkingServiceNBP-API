using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsNeo4J
{
    public class Neo4JControl
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsPenalty { get; set; }
        public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }
        public string ControllorId { get; set; }
    }
}
