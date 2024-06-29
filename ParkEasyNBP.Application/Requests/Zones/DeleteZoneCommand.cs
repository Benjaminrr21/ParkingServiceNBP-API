using MediatR;

namespace ParkEasyNBP.Application.Requests.Zones
{
    public class DeleteZoneCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteZoneCommand(int id)
        {
            this.Id = id;
        }
    }
}
