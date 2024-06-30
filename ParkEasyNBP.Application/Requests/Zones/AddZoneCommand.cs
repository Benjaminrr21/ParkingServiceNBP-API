using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models;

namespace ParkEasyNBP.Application.Requests.Zones
{
    public class AddZoneCommand : IRequest<Zone>
    {
        public ZoneCreateDTO Zone { get; set; }
        public AddZoneCommand(ZoneCreateDTO zone)
        {
            this.Zone = zone;
        }
    }
}
