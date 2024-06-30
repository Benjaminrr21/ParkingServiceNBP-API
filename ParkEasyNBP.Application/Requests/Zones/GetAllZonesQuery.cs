using MediatR;
using ParkEasyNBP.Application.DTOs;
using System.Collections.Generic;

namespace ParkEasyNBP.Application.Requests.Zones
{
    public class GetAllZonesQuery : IRequest<IEnumerable<ZonesDTO>>
    {
    }
}
