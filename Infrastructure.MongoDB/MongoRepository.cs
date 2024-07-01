using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.MongoDB
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> collection;

        public MongoRepository(IMongoClient client, IOptions<MongoDBSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name + "s");
        }
        public async Task<T> Create(T entity)
        {
            await collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task Delete(string id)
        {
            await collection.DeleteOneAsync(id);

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task Update(string id, T entity)
        {
            await collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id",id),entity);

        }
    }
}
