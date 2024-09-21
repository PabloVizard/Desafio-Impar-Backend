using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application
{
    public class CardApp : BaseApp<Card, CardModel>, ICardApp
    {
        protected readonly ICardService _cardService;
        protected readonly IMapper _mapper;

        public CardApp(ICardService cardService, IMapper mapper) : base(cardService, mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }
    }
}
