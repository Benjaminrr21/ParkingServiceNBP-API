using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Command
{
    public class DeleteParkingPlaceCommand : IRequest<Result<ParkingPlaceGetDTO>>
    {
        public int Id { get; set; }
        public DeleteParkingPlaceCommand(int id)
        {
            Id = id;
        }
    }
}
