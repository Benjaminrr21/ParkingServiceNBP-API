using MediatR;
using ParkEasyNBP.Application.Requests.Zones;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.Handlers.Zones
{
    public class GetZoneByIdQueryHandler : IRequestHandler<GetZoneByIdQuery, Zone>
    {
        private readonly IZoneRepository _zoneRepository;

        public GetZoneByIdQueryHandler(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        public async Task<Zone> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            return await _zoneRepository.Get(request.Id);
        }
    }
}
