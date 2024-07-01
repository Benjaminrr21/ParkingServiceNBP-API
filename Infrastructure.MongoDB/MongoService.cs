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
    public class MongoService 
    {
         private IMongoCollection<MongoZone> zones;
         private IMongoCollection<MongoParkingPlace> parkingPlaces;

         public MongoService()
         {

             MongoClient client = new MongoClient("mongodb://localhost:27017");
             IMongoDatabase db = client.GetDatabase("ParkEasyProject");
             zones = db.GetCollection<MongoZone>("Zones");
             parkingPlaces = db.GetCollection<MongoParkingPlace>("Parking places");
         }
         public async Task<MongoZone> Create(MongoZone zone)
         {
             await zones.InsertOneAsync(zone);
             return zone;
         }

         public async Task<List<MongoZone>> GetAll()
         {
             var f = new BsonDocument();
             return zones.Find(f).ToList();
         }
      
    }
}
