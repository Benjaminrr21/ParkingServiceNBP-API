using MongoDB.Bson;
using MongoDB.Driver;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.MongoDB
{
    public class ParkingPlaceServiceMongoDB : IMongoRepository<ParkingPlaceMongoDB>
    {
        private IMongoCollection<ParkingPlaceMongoDB> parkingPlaces;

        public ParkingPlaceServiceMongoDB()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("ParkEasyProject");
            //parkingPlaces = db.GetCollection<ParkingPlaceMongoDB>("Zones");
            parkingPlaces = db.GetCollection<ParkingPlaceMongoDB>("Parking places");
        }

        public async Task<ParkingPlaceMongoDB> Create(ParkingPlaceMongoDB zone)
        {
            await parkingPlaces.InsertOneAsync(zone);
            return zone;
        }

        public async Task<List<ParkingPlaceMongoDB>> GetAll()
        {
            var f = new BsonDocument();
            return parkingPlaces.Find(f).ToList();
        }
    }
}
