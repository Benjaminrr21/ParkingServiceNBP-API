using AutoMapper;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ParkingPlaceCreateDTO, ParkingPlace>();
            CreateMap<ZoneCreateDTO, Zone>();
        }
    }
}
