using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsMongoDB
{
    public class MongoOneOffCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }
        public DateTime DateTimeSelling { get; set; }
        public DateTime Period { get; set; }
        public string VehicleId { get; set; }
       // public Vehicle Vehicle { get; set; }
    }
}
