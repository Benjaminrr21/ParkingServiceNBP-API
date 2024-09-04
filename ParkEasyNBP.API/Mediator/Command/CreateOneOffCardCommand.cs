using MediatR;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Command
{
    public class CreateOneOffCardCommand : IRequest<Result<OneOffCard>>
    {
        public string Code { get;  }
        public int VehicleId { get;  }

        public CreateOneOffCardCommand(string code, int vehicleId)
        {
            Code = code;
            VehicleId = vehicleId;
        }
    }
}
