using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Infrastructure.SqlServer;



namespace Repository.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly ParkDbContext context;
        public VehicleRepository(ParkDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
