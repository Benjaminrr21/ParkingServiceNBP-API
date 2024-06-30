using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IParkingPlaceRepository ParkingPlaceRepository { get; }
        //IVehicleRepository VehicleRepository { get; }
        //IUserRepository UserRepository { get; }
        ISubscriptionCardRepository SubscriptionCardRepository { get; }
        IOneOffCardRepository OneOffCardRepository { get; }

        Task CompleteAsync(); //cuva sve promene napravljene u bazi podataka

    }
}
