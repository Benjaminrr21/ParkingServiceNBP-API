using MediatR;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Command
{
    public class CreateOneOffCardCommand : IRequest<Result<OneOffCard>>
    {
        public string Code { get; set; }
        public int VehicleId { get; set; }

        public CreateOneOffCardCommand(string code, int vehicleId)
        {
            Code = code;
            VehicleId = vehicleId;
        }
    }
}
