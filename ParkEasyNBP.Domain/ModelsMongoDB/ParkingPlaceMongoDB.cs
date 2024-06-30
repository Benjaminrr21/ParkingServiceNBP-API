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
    public class ParkingPlaceMongoDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Status { get; set; } = "Free";
        public string Street { get; set; }
       /* public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int ZoneId { get; set; } // Može biti null
        public virtual Zone Zone { get; set; }
        public int? PublicGarageId { get; set; } // Može biti null
        public PublicGarage PublicGarage { get; set; }*/

        public bool? IsUnderground { get; set; } // Može biti null
        public int? GarageLevel { get; set; } // Može biti null
    }
}
