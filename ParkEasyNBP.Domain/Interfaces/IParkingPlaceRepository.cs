using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Interfaces
{
    public interface IParkingPlaceRepository : IRepository<ParkingPlace>
    {
        Task<IQueryable<ParkingPlace>> GetALllQ();
        Task<ParkingPlace> ReservePlace(int vid, int pid);
        Task<ParkingPlace> FreePlace(int vid, int pid);
        Task<ParkingPlace> AddPlaceWithGarage(ParkingPlace p);
   
    }
}
