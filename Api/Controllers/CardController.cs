using Application.Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : BaseController<Card, CardModel>
    {
        private readonly ICardApp _cardApp;
        private readonly IPhotoApp _photoApp;
        private readonly IMapper _mapper;
        public CardController(ICardApp cardApp, IMapper mapper, IPhotoApp photoApp) : base(cardApp, mapper)
        {
            _cardApp = cardApp;
            _photoApp = photoApp;
        }
    }
}
