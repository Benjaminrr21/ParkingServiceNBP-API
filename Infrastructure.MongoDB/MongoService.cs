using MongoDB.Bson;
using MongoDB.Driver;
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
        private IMongoCollection<ZoneMongoDB> zones;

        public MongoService()
        {

            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("ParkEasyProject");
            zones = db.GetCollection<ZoneMongoDB>("Zones");
        }
        public async Task<ZoneMongoDB> Create(ZoneMongoDB zone)
        {
            await zones.InsertOneAsync(zone);
            return zone;
        }
        public async Task<List<ZoneMongoDB>> GetAll()
        {
            var f = new BsonDocument();
            return zones.Find(f).ToList();
        }
    }
}
