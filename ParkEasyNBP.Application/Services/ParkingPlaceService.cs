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

        public async Task<IEnumerable<ParkingPlaceGetDTO>> GetAll()
        {
            return mapper.Map<IEnumerable<ParkingPlaceGetDTO>>(await parkingPlaceRepository.GetAll());
        }
        public async Task<ParkingPlaceGetDTO> Get(int id)
        {
            return mapper.Map<ParkingPlaceGetDTO>(await parkingPlaceRepository.Get(id));
        }
        public async Task<ParkingPlaceGetDTO> Create(ParkingPlaceCreateDTO p)
        {
            var pp = mapper.Map<ParkingPlace>(p);   
            await parkingPlaceRepository.Create(pp);
            return mapper.Map<ParkingPlaceGetDTO>(pp);

        }
        public async Task<ParkingPlaceGetDTO> Delete(int id)
        {
            var pp = mapper.Map<ParkingPlaceGetDTO>(await parkingPlaceRepository.Delete(id));
            return pp;
        }
        public async Task<ParkingPlaceGetDTO> Update(int id, ParkingPlaceUpdateDTO p)
        {
            return mapper.Map<ParkingPlaceGetDTO>(await parkingPlaceRepository.Update(id, mapper.Map<ParkingPlace>(p)));
        }
        public async Task<ParkingPlaceGetDTO> CreateSimple(ParkingPlaceCreateSimple p)
        {
            var pp = mapper.Map<ParkingPlace>(p);
            await parkingPlaceRepository.Create(pp);
            return mapper.Map<ParkingPlaceGetDTO>(pp);

        }
    }
}
