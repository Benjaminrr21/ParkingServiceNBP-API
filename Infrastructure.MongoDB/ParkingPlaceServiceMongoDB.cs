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
    public class ParkingPlaceServiceMongoDB  //IMongoRepository<ParkingPlaceMongoDB>
    {
        private IMongoCollection<MongoParkingPlace> parkingPlaces;

        public ParkingPlaceServiceMongoDB()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("ParkEasyProject");
            //parkingPlaces = db.GetCollection<ParkingPlaceMongoDB>("Zones");
            parkingPlaces = db.GetCollection<MongoParkingPlace>("Parking places");
        }

        public async Task<MongoParkingPlace> Create(MongoParkingPlace zone)
        {
            await parkingPlaces.InsertOneAsync(zone);
            return zone;
        }

        public async Task<List<MongoParkingPlace>> GetAll()
        {
            var f = new BsonDocument();
            return parkingPlaces.Find(f).ToList();
        }
    }
}
