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
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, Zone>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public UpdateZoneCommandHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<Zone> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = _mapper.Map<Zone>(request.Zone);
            zone.Id = request.Id;
            return await _zoneRepository.Update(request.Id, zone);
        }
    }
}
