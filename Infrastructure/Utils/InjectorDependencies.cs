using Application.Application;
using Application.Application.Interfaces;
using Application.Mappings;
using Application.Models;
using Application.Validators;
using Domain.Repositories.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class InjectorDependencies
    {
        public static void Registrer(IServiceCollection services)
        {
            #region Validators
            services.AddScoped<IValidator<PhotoModel>, PhotoValidator>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(BaseMappings));
            #endregion

            #region Application

            services.AddScoped(typeof(IBaseApp<,>), typeof(BaseApp<,>));
            services.AddScoped<ICardApp, CardApp>();
            services.AddScoped<IPhotoApp, PhotoApp>();

            #endregion

            #region Services

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IPhotoService, PhotoService>();

            #endregion

            #region Repositories 

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            #endregion
        }
    }
}
