using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.Neo4j.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Neo4jRepositories
{
    public class ZoneGraphRepository : IZoneRepository
    {
        private readonly ZonesService context;

        public ZoneGraphRepository(ZonesService context)
        {
            this.context = context;
        }
        public async Task<Zone> Create(Zone entity)
        {
            await context.Create(entity);
            return entity;
        }

        public Task<Zone> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Zone> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Zone>> GetAll()
        {
            return await context.GetAll();
        }

        public Task<Zone> Update(int id, Zone entity)
        {
            throw new NotImplementedException();
        }
    }
}
