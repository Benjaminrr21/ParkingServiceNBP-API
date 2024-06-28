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
        /// <summary>
        /// public IVehicleRepository VehicleRepository { get; private set; }
        /// </summary>

        public IUserRepository UserRepository { get; private set; }

        public ISubscriptionCardRepository SubscriptionCardRepository {  get; private set; }

        public IOneOffCardRepository OneOffCardRepository {  get; private set; }

        public UnitOfWork(ParkDbContext context)
        {
            this.context = context;
            ParkingPlaceRepository = new ParkingPlaceRepository(context);
           // VehicleRepository = new VehicleRepository(context);
            SubscriptionCardRepository = new SubscriptionCardRepository(context);
            OneOffCardRepository = new OneOffCardRepository(context);
            //UserRepository = new UserRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
