using MongoDB.Driver;
using ParkEasyNBP.Domain.ModelsMongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.MongoDB
{
    public class ZoneService : MongoRepository<ZoneMongoDB>, IZoneService
    {
        /* private readonly MongoRepository<ZoneMongoDB> _repository;

         public ZoneService(MongoRepository<ZoneMongoDB> repository)
         {
             _repository = repository;
         }

         public async Task<ZoneMongoDB> Create(ZoneMongoDB zone)
         {
             return await _repository.Create(zone);
         }

         public async Task<List<ZoneMongoDB>> GetAll()
         {
             return await _repository.GetAll();
         }*/
        public ZoneService(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}
