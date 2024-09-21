using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CardValidator : AbstractValidator<CardModel>
    {
        public CardValidator()
        {
            RuleFor(card => card.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.");

            RuleFor(card => card.Photo)
                .SetValidator(new PhotoValidator());

            RuleFor(card => card.Status)
                .IsInEnum()
                .WithMessage("O status é inválido. Por favor, forneça um valor válido.");
        }
    }
}
