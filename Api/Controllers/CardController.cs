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

        [HttpPost]
        [Route("Registrar")]
        public override async Task<IActionResult> Registrar(CardModel dados)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var photoModel = new PhotoModel
                {
                    Base64 = dados.Photo.Base64
                };

                var cardEntity = await _cardApp.Add(dados);
                await _cardApp.SaveChangesAsync();

                return Ok(((EntityEntry<Card>)cardEntity).Entity);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    return BadRequest("O registro com o mesmo valor já existe. Por favor, verifique seus dados.");
                }

                return BadRequest("Erro Inesperado");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }

    }
}
