using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsMongoDB
{
    public class MongoVehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string UserId { get; set; }
    }
}
