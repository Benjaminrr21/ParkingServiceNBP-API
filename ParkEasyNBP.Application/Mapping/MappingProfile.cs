using AutoMapper;
using ParkEasyNBP.Application.DTOs;
using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Application.DTOs.ControlDTO;
using ParkEasyNBP.Application.DTOs.MongoDB_DTOs;
using ParkEasyNBP.Application.DTOs.Penalties;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Domain.ModelsMongoDB;
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
            CreateMap<CredentialModel, ApplicationUser>();

            CreateMap<ParkingPlaceCreateDTO, ParkingPlace>();
            CreateMap<ZoneCreateDTO, Zone>();

            CreateMap<NewVehicleDTO, Vehicle>();
            CreateMap<VehicleUpdateDTO,Vehicle>();
            CreateMap<Vehicle,VehicleWithInfosDTO>();
            CreateMap<Vehicle,VehicleOfCardDTO>();
            CreateMap<Vehicle,VehicleControlDTO>();

            CreateMap<ControlDTO, Control>();

            CreateMap<NewPenaltyDTO,Penalty>();
            CreateMap<Penalty,PenaltyOfVehicleDTO>();

            CreateMap<Zone,ZonesDTO>();
            CreateMap<ParkingPlace,ParkingPlaceGetDTO>();
            CreateMap<PublicGarage,PublicGarageGetDTO>();
            CreateMap<ParkingPlaceUpdateDTO, ParkingPlace>();
            CreateMap<ParkingPlaceCreateSimple, ParkingPlace>();

            CreateMap<SubscriptionCard, SCardOfVehicle>();
            CreateMap<NewSCard, SubscriptionCard>();

            CreateMap<AddNewOOCard, OneOffCard>();
            CreateMap<OneOffCard, OOCardOfVehicle>();

            CreateMap<Control, ControlDTO>();
            CreateMap<NewControlDTO, Control>();

            CreateMap<ApplicationUser, OwnerDTO>();
            CreateMap<ApplicationUser, ControllorDTO>();

            CreateMap<ApplicationUser, serDTO>();

            CreateMap<ZoneMongoDTO, MongoZone>();
            CreateMap<NewParkingPlaceMongoDTO, MongoParkingPlace>();
            CreateMap<NewVehicleMongo, MongoVehicle>();
        }
    }
}
