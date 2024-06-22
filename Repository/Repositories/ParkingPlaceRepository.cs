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
        public async Task<IEnumerable<ParkingPlace>> GetAll()
        {
            return await dbContext.ParkingPlaces.ToListAsync();
        }

        public async Task<ParkingPlace> Create(ParkingPlace parkingPlace)
        {
            await dbContext.AddAsync(parkingPlace);
            await dbContext.SaveChangesAsync();
            return parkingPlace;
        }
    }
}
