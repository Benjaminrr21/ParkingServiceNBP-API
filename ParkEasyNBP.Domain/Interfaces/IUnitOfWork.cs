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
        IUserRepository UserRepository { get; }

        Task CompleteAsync(); //cuva sve promene napravljene u bazi podataka

    }
}
