using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ParkEasyNBP.Application.Requests.Zones;
using MediatR;
using AutoMapper;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;

namespace ParkEasyNBP.Application.Handlers.Zones
{
    public class GetAllZonesQueryHandler : IRequestHandler<GetAllZonesQuery, IEnumerable<ZonesDTO>>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public GetAllZonesQueryHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ZonesDTO>> Handle(GetAllZonesQuery request, CancellationToken cancellationToken)
        {
            var zones = await _zoneRepository.GetAll();
            return _mapper.Map<IEnumerable<ZonesDTO>>(zones);
        }
    }
}
