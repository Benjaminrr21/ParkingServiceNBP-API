using MediatR;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Handler
{
    public class CreateZoneHandler : IRequestHandler<CreateZoneCommand, Result<Zone>>
    {
        private readonly ZoneServiceM service;

        public CreateZoneHandler(ZoneServiceM service)
        {
            this.service = service;
        }
        public async Task<Result<Zone>> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var zonedto = new ZoneCreateDTO()
            {
                Address = request.Address,
                NumberOfPlaces = request.NumberOfPlaces,
                Name = request.Name,
            };
            var newZone = await service.Create(zonedto);
            if(newZone == null)
            {
                return new Result<Zone>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "There is one error..."}

                };

            }
            return new Result<Zone>
            {
                Data = newZone
            };
        }
    }
}
