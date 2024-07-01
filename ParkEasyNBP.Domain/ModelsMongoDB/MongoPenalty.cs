using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsMongoDB
{
    public class MongoPenalty
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Why { get; set; }
        public bool IsPay { get; set; } = false;
        public decimal Price { get; set; }
        public string? Reason { get; set; }
        public DateTime DateTime { get; set; }

        public string VehicleId { get; set; }
    }
}
