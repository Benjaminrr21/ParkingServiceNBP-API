using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsNeo4J
{
    public class Neo4JPenalty
    {
        public int Id { get; set; }
        public string Why { get; set; }
        public bool IsPay { get; set; } = false;
        public decimal Price { get; set; }
        public string? Reason { get; set; }
        public DateTime DateTime { get; set; }

        public int VehicleId { get; set; }
    }
}
