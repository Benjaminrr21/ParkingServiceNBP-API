using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsNeo4J
{
    public class Neo4JVehicle
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string UserId { get; set; }
    }
}
