using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.ModelsMongoDB
{
    public class MongoSubscriptionCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }
        public DateTime Period { get; set; }
        //public int RegisterNumber { get; set; }
        public string VehicleId { get; set; }
    }
}
