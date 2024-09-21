using Application.Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : BaseController<Card, CardModel>
    {
        private readonly ICardApp _cardApp;
        private readonly IPhotoApp _photoApp;
        public CardController(ICardApp cardApp, IPhotoApp photoApp) : base(cardApp)
        {
            _cardApp = cardApp;
            _photoApp = photoApp;
        }
    }
}
