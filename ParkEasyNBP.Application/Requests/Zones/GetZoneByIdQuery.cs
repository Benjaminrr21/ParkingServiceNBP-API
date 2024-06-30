using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ParkEasyNBP.Domain.Models;

namespace ParkEasyNBP.Application.Requests.Zones
{
    public class GetZoneByIdQuery : IRequest<Zone>
    {
        public int Id { get; set; }
        public GetZoneByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
