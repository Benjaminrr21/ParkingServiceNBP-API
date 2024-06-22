using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Infrastructure.SqlServer;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkDbContext context;

        public IParkingPlaceRepository ParkingPlaceRepository {  get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(ParkDbContext context)
        {
            this.context = context;
            ParkingPlaceRepository = new ParkingPlaceRepository(context);
            //UserRepository = new UserRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
