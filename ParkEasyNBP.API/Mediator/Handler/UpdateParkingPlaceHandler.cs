using MediatR;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models.Results;
using Repository.Repositories;

namespace ParkEasyNBP.API.Mediator.Handler
{
    public class UpdateParkingPlaceHandler : IRequestHandler<UpdateParkingPlaceCommand, Result<ParkingPlaceGetDTO>>
    {
        private readonly ParkingPlaceService service;

        public UpdateParkingPlaceHandler(ParkingPlaceService service)
        {
            this.service = service;
        }

        public async Task<Result<ParkingPlaceGetDTO>> Handle(UpdateParkingPlaceCommand request, CancellationToken cancellationToken)
        {

            var pp = new ParkingPlaceUpdateDTO()
            {
                
                Status = request.Status,
                Street = request.Street,
                ZoneId = request.ZoneId
            };
            var updated = await service.Update(request.Id, pp);
            return new Result<ParkingPlaceGetDTO>
            {
                Data = updated,
                IsSuccess = true
            };
        }
    }
}
