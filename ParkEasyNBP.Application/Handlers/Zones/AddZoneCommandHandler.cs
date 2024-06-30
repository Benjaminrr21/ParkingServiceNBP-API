using MediatR;
using AutoMapper;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using ParkEasyNBP.Application.Requests.Zones;

namespace ParkEasyNBP.Application.Handlers.Zones
{
    public class AddZoneCommandHandler : IRequestHandler<AddZoneCommand, Zone>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public AddZoneCommandHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<Zone> Handle(AddZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = _mapper.Map<Zone>(request.Zone);
            await _zoneRepository.Create(zone);
            return zone;
        }
    }
}
