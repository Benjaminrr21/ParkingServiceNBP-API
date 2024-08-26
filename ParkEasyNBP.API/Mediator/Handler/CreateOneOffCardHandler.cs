using MediatR;
using ParkEasyNBP.API.Mediator.Command;
using ParkEasyNBP.Application.Services;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.Models.Results;
using ParkEasyNBP.Application.DTOs.CardsDTO;

namespace ParkEasyNBP.API.Mediator.Handler
{
    public class CreateOneOffCardHandler : IRequestHandler<CreateOneOffCardCommand,Result<OneOffCard>>
    {
        private readonly OneOffCardService service;

        public CreateOneOffCardHandler(OneOffCardService service)
        {
            this.service = service;
        }

        public async Task<Result<OneOffCard>> Handle(CreateOneOffCardCommand request, CancellationToken cancellationToken)
        {
            var card = new AddNewOOCard()
            {
                Code = request.Code,
                VehicleId = request.VehicleId,
            };
            var newCard = await service.Create(card);
            if (newCard == null)
            {
                return new Result<OneOffCard>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "There is some error." }
                };

            }
            return new Result<OneOffCard> { Data = newCard };
        }
    }
}
