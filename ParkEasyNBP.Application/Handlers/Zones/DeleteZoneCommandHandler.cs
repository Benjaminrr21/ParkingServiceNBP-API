using MediatR;
using ParkEasyNBP.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using ParkEasyNBP.Application.Requests.Zones;
using ParkEasyNBP.Domain.Models;

namespace ParkEasyNBP.Application.Handlers.Zones
{
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand, bool>
    {
        private readonly IZoneRepository _zoneRepository;

        public DeleteZoneCommandHandler(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        public async Task<bool> Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            var deletedZone = await _zoneRepository.Delete(request.Id);
            return deletedZone != null; 
        }
    }
}
