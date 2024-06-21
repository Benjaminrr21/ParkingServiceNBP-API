using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.Services
{
    public class ParkingPlaceService 
    {
        private readonly IParkingPlaceRepository parkingPlaceRepository;

        public ParkingPlaceService(IParkingPlaceRepository parkingPlaceRepository)
        {
            this.parkingPlaceRepository = parkingPlaceRepository;
        }

        public async Task<IEnumerable<ParkingPlace>> GetAll()
        {
            return await parkingPlaceRepository.GetAll();
        }
    }
}
