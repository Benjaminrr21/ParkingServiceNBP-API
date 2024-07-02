using MediatR;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Handler
{
    public class DeleteParkingPlaceCommandHandler : IRequestHandler<DeleteParkingPlaceCommand, Result<ParkingPlaceGetDTO>>
    {
        private readonly ParkingPlaceService service;

        public DeleteParkingPlaceCommandHandler(ParkingPlaceService service)
        {
            this.service = service;
        }
        public async Task<Result<ParkingPlaceGetDTO>> Handle(DeleteParkingPlaceCommand request, CancellationToken cancellationToken)
        {
            var deletedPp = await service.Delete(request.Id);
            if (deletedPp != null)
            {
                return new Result<ParkingPlaceGetDTO>
                {
                    Data = deletedPp,
                    IsSuccess = true
                };


            }
            return new Result<ParkingPlaceGetDTO>
            {
                IsSuccess = false,
                Errors = new List<string>() { "Ne moze se izbrisati nepostojece parking mesto." }
            };
        }
    }
        
}
