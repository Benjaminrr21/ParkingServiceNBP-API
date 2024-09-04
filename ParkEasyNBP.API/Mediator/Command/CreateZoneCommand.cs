using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;

namespace ParkEasyNBP.API.Mediator.Command
{
    public class CreateZoneCommand : IRequest<Result<Zone>>
    {
        public string Name { get; }
        public int NumberOfPlaces { get;  }
        public string Address { get;  }
        public CreateZoneCommand(string name, int numberOfPlaces, string address)
        {
            Name = name;
            NumberOfPlaces = numberOfPlaces;
            Address = address;
        }

    }
}
