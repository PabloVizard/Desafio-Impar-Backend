using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CardService : BaseService<Card>, ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardService(ICardRepository cardRepository, IMapper mapper) : base(cardRepository, mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }
    }
}
