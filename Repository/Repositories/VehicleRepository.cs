using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Infrastructure.SqlServer;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;



namespace Repository.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly ParkDbContext context;
 
        

        public VehicleRepository(ParkDbContext context) : base(context)
 
        {
            this.context = context;
        }
        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            ///throw new NotImplementedException();
            return await context.Vehicles.Include(z => z.Penalties).Include(z => z.OneOffCards).Include(z=>z.SubscriptionCards).ToListAsync();

        }
        public async Task<Vehicle> Get(int id)
        {
            //throw new NotImplementedException();

            var v = await context.Vehicles.Include(v => v.Penalties).FirstOrDefaultAsync(v => v.Id == id);
            return v;
        }

        public async Task<Vehicle> VehicleOfOwner(string id)
        {
            throw new NotImplementedException();

            //return await context.Vehicles.FirstOrDefaultAsync(v => v.UserId == id);
           
        }
    }
}
