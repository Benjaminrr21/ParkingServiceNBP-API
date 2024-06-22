using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ZoneRepository : Repository<Zone>, IZoneRepository
    {
        private readonly ParkDbContext dbContext;

        public ZoneRepository(ParkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Zone>> GetAll()
        {
            return await dbContext.Zones.ToListAsync();
        }
        public async Task<Zone?> Get(int id)
        {
            return await dbContext.Zones.FindAsync(id);
        }
        public async Task<Zone> Create(Zone zone)
        {
            await dbContext.Zones.AddAsync(zone);
            await dbContext.SaveChangesAsync();
            return zone;
        }
        public async Task<Zone?> Delete(int id)
        {
            var zone = await dbContext.Zones.FindAsync(id);
            if (zone != null)
            {
                dbContext.Remove(zone);
                await dbContext.SaveChangesAsync();
            }
            return zone;
        }
        public async Task<Zone> Update(int id, Zone entity)
        {
            var existingEntity = await dbContext.Zones.FindAsync(id);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await dbContext.SaveChangesAsync();
                return existingEntity;
            }
            return null; 
        }

    }
}
