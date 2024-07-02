using MediatR;
using ParkEasyNBP.API.Mediator.Query;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Exceptions;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Handler
{
    public class ParkingPlaceIdQueryHandler : IRequestHandler<ParkingPlaceIdQuery, Result<ParkingPlaceGetDTO>>
    {
        private readonly ParkingPlaceService service;

        public ParkingPlaceIdQueryHandler(ParkingPlaceService service)
        {
            this.service = service;
        }
        public async Task<Result<ParkingPlaceGetDTO>> Handle(ParkingPlaceIdQuery request, CancellationToken cancellationToken)
        {
            var pp = await service.Get(request.Id);
            if(pp == null)
            {
                //throw new EntityNullException();
                return new Result<ParkingPlaceGetDTO>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Nije pronadjeno parking mesto s datim ID-em." }
                };
            }
            return new Result<ParkingPlaceGetDTO>
            {
                IsSuccess = true,
                Data = pp
            };
        }
    }
}
