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
    public class MongoPublicGarage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfPlaces { get; set; }
        public int NumberOfFreePlaces { get; set; }
        public string WorkingTime { get; set; }
        //public ICollection<ParkingPlace> ParkingPlaces { get; set; }
        //public Zone Zone { get; set; }
        public string ZoneId { get; set; }
    }
}
