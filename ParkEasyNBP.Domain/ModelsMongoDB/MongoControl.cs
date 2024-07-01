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
    public class MongoControl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsPenalty { get; set; }
        public string VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }
        public string ControllorId { get; set; }
    }
}
