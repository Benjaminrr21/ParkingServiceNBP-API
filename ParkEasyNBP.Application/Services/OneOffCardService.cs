using AutoMapper;
using ParkEasyNBP.Application.DTOs.CardsDTO;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.Services
{
    public class OneOffCardService
    {
        private readonly IOneOffCardRepository repository;
        private readonly IMapper mapper;

        public OneOffCardService(IOneOffCardRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<OneOffCard> Create(AddNewOOCard card)
        {
            return await repository.Create(mapper.Map<OneOffCard>(card));
        }
    }
}
