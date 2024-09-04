using AutoMapper;
using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.Services
{
    public class ZoneServiceM
    {
        private readonly IMapper mapper;
        private readonly IZoneRepository zoneRepository;

        public ZoneServiceM(IMapper mapper, IZoneRepository zoneRepository)
        {
            this.mapper = mapper;
            this.zoneRepository = zoneRepository;
        }
        public async Task<IEnumerable<ParkingPlaceGetDTO>> GetAll()
        {
            return mapper.Map<IEnumerable<ParkingPlaceGetDTO>>(await zoneRepository.GetAll());
        }
        public async Task<ParkingPlaceGetDTO> Get(int id)
        {
            return mapper.Map<ParkingPlaceGetDTO>(await zoneRepository.Get(id));
        }
        public async Task<Zone> Create(ZoneCreateDTO p)
        {
            var pp = mapper.Map<Zone>(p);
            await zoneRepository.Create(pp);
            return pp;

        }
        public async Task<ParkingPlaceGetDTO> Delete(int id)
        {
            var pp = mapper.Map<ParkingPlaceGetDTO>(await zoneRepository.Delete(id));
            return pp;
        }
        public async Task<ParkingPlaceGetDTO> Update(int id, ParkingPlaceUpdateDTO p)
        {
            return mapper.Map<ParkingPlaceGetDTO>(await zoneRepository.Update(id, mapper.Map<Zone>(p)));
        }
        public async Task<ParkingPlaceGetDTO> CreateSimple(ParkingPlaceCreateSimple p)
        {
            var pp = mapper.Map<Zone>(p);
            await zoneRepository.Create(pp);
            return mapper.Map<ParkingPlaceGetDTO>(pp);

        }


    }
}
