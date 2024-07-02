using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Query
{
    public class ParkingPlaceIdQuery : IRequest<Result<ParkingPlaceGetDTO>>
    {
        public int Id { get;  }
        public ParkingPlaceIdQuery(int id)
        {
            Id = id;
        }
    }
}
