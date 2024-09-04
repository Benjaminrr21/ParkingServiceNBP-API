using Microsoft.EntityFrameworkCore;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ParkingPlaceRepository : Repository<ParkingPlace>, IParkingPlaceRepository
    {
        private readonly ParkDbContext dbContext;

        public ParkingPlaceRepository(ParkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ParkingPlace> ReservePlace(int vid, int pid)
        {
            var pp = await dbContext.ParkingPlaces.FindAsync(pid);
            //var vehicle = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == vid);
            var pcard = await dbContext.OneOffCards.FirstOrDefaultAsync(c => c.VehicleId == vid);
            
            //if (pcard.Period < DateTime.Now) return null;
            
                pp.Status = "ZAUZETO";
                pp.VehicleId = vid;
                await dbContext.SaveChangesAsync();
                return pp;
            
        }
        public async Task<ParkingPlace> FreePlace(int vid, int pid)
        {
            var pp = await dbContext.ParkingPlaces.FindAsync(pid);
            pp.Status = "SLOBODNO";
            pp.VehicleId = null;
            await dbContext.SaveChangesAsync();
            return pp;
        }

        public async Task<ParkingPlace> AddPlaceWithGarage(ParkingPlace p)
        {
           
                await dbContext.AddAsync(p);
                await dbContext.SaveChangesAsync();
                return p;
            
        }

        public async Task<IQueryable<ParkingPlace>> GetALllQ()
        {
            return dbContext.ParkingPlaces.AsQueryable();
        }
        /* public async Task<ParkingPlace> Update(int id, ParkingPlace entity)
{
var existingEntity = await dbContext.Set<ParkingPlace>()
//.Include(pp => pp.Zone) // Include related entities if necessary
.FirstOrDefaultAsync(pp => pp.Id == id);

if (existingEntity != null)
{
dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

// Ensure the Id remains unchanged
existingEntity.Id = id;
// If there are any properties that should not be updated, handle them here

await dbContext.SaveChangesAsync();
return existingEntity;
}
return null; // Handle this according to your scenario
}*/

        /* public async Task<IEnumerable<ParkingPlace>> GetAll()
         {
             return await dbContext.ParkingPlaces.ToListAsync();
         }

         public async Task<ParkingPlace> Create(ParkingPlace parkingPlace)
         {
             await dbContext.AddAsync(parkingPlace);
             await dbContext.SaveChangesAsync();
             return parkingPlace;
         }*/
    }
}
