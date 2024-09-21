using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class PhotoValidator : AbstractValidator<PhotoModel>
    {
        public PhotoValidator()
        {
            RuleFor(photo => photo.Base64)
                .Must(BeAValidBase64) 
                .WithMessage("A imagem fornecida não é uma string Base64 válida.");
        }

        private bool BeAValidBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
