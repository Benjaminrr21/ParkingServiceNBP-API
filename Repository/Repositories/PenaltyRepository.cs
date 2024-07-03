using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PenaltyRepository  :Repository<Penalty>, IPenaltyRepository
    {
        private readonly ParkDbContext dbContext;

        public PenaltyRepository(ParkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Penalty> Create(Penalty p)
        {
            p.DateTime = DateTime.Now;
            await dbContext.AddAsync(p);
            await dbContext.SaveChangesAsync();
            return p;
        }

        public async Task<IEnumerable<Penalty>> GetPenaltiesOfVehicle(int vid)
        {
            return await dbContext.Penalties.Where(p => p.VehicleId == vid).ToListAsync();
        }

        public async Task<Penalty> RemovePenalty(int id,string reason)
        {
            var p = await dbContext.Penalties.FindAsync(id);
            p.IsPay = true;
            p.Reason = reason;
            await dbContext.SaveChangesAsync();
            return p;
        }
       
    }
}
