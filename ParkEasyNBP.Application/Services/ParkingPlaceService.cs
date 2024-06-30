using AutoMapper;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.Services
{
    public class ParkingPlaceService 
    {
        private readonly IParkingPlaceRepository parkingPlaceRepository;
        private readonly IMapper mapper;

        public ParkingPlaceService(IParkingPlaceRepository parkingPlaceRepository, IMapper mapper)
        {
            this.parkingPlaceRepository = parkingPlaceRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ParkingPlace>> GetAll()
        {
            return await parkingPlaceRepository.GetAll();
        }
        public async Task<ParkingPlaceGetDTO> Create(ParkingPlaceCreateDTO p)
        {
            var pp = mapper.Map<ParkingPlace>(p);   
            await parkingPlaceRepository.Create(pp);
            return mapper.Map<ParkingPlaceGetDTO>(pp);

        }
        public async Task<ParkingPlaceGetDTO> CreateSimple(ParkingPlaceCreateSimple p)
        {
            var pp = mapper.Map<ParkingPlace>(p);
            await parkingPlaceRepository.Create(pp);
            return mapper.Map<ParkingPlaceGetDTO>(pp);

        }
    }
}
