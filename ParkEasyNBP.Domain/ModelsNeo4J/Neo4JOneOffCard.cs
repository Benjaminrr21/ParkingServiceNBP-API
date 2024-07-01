using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsNeo4J
{
    public class Neo4JOneOffCard
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateTimeSelling { get; set; }
        public DateTime Period { get; set; }
        public int VehicleId { get; set; }
    }
}
