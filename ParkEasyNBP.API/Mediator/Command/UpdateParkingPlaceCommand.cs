using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Command
{
    public class UpdateParkingPlaceCommand : IRequest<Result<ParkingPlaceGetDTO>>
    {
        public int Id { get; set; }
        public string Status { get;  }
        public string Street { get;  }
        public int ZoneId { get;  }
        public UpdateParkingPlaceCommand(int id, string status, string street, int zoneId)
        {
            Id = id;
            Status = status;
            Street = street;
            ZoneId = zoneId;
        }
    }
}
