using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
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
        //private readonly UserManager<ApplicationUser> userManager;

        public IOneOffCardRepository OneOffCardRepository { get; private set; }
        public IParkingPlaceRepository ParkingPlaceRepository {  get; private set; }
        public IPenaltyRepository PenaltyRepository { get; private set; }
        public ISubscriptionCardRepository SubscriptionCardRepository { get; private set; }
        //public IUserRepository UserRepository { get; private set; }
        public IVehicleRepository VehicleRepository { get; private set; }
        public IZoneRepository ZoneRepository { get; private set; }
        

        public UnitOfWork(ParkDbContext context)
        {
            this.context = context;
            OneOffCardRepository = new OneOffCardRepository(context);
            ParkingPlaceRepository = new ParkingPlaceRepository(context);
            PenaltyRepository = new PenaltyRepository(context);
            SubscriptionCardRepository = new SubscriptionCardRepository(context);
            //UserRepository = new UserRepository(context);
            VehicleRepository = new VehicleRepository(context);
            ZoneRepository = new ZoneRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
