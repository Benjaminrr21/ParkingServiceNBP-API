using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Command
{
    public class CreateParkingPlaceCommand : IRequest<Result<ParkingPlaceGetDTO>>
    {

          public string Status { get;  }
          public string Street { get;  }
          public int ZoneId { get;  }
         
        public CreateParkingPlaceCommand(string status, string street, int zoneId)
        {
            Status = status;
            Street = street;
            ZoneId = zoneId;

        }
    }
}
