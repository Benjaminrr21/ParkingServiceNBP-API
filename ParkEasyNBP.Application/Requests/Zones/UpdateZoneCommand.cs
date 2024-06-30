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
    public class UpdateZoneCommand : IRequest<Zone>
    {
        public int Id { get; set; }
        public ZoneCreateDTO Zone { get; set; }
        public UpdateZoneCommand(int id, ZoneCreateDTO zone)
        {
            this.Id = id;
            this.Zone = zone;
        }
    }
}

