using MediatR;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Handler
{
    public class CreateParkingPlaceHandler : IRequestHandler<CreateParkingPlaceCommand, Result<ParkingPlaceGetDTO>>
    {
        private readonly ParkingPlaceService service;

        public CreateParkingPlaceHandler(ParkingPlaceService service)
        {
            this.service = service;
        }
        public async Task<Result<ParkingPlaceGetDTO>> Handle(CreateParkingPlaceCommand request, CancellationToken cancellationToken)
        {
            
            var p = new ParkingPlaceCreateSimple()
            {
                Status = request.Status,
                Street = request.Street,
                ZoneId = request.ZoneId,
                
            };

            var parking = await service.CreateSimple(p);
            if(parking == null)
            {
                return new Result<ParkingPlaceGetDTO>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "There is some error." }

                };
            }
            return new Result<ParkingPlaceGetDTO>
            {
                Data = parking
            };
        }
    }
}
