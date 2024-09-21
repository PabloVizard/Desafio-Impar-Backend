using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class PhotoApp : BaseApp<Photo, PhotoModel>, IPhotoApp
    {
        protected readonly IPhotoService _photoService;
        protected readonly IMapper _mapper;
        public PhotoApp(IPhotoService photoService, IMapper mapper) : base(photoService, mapper)
        {
            _photoService = photoService;
            _mapper = mapper;
        }
    }
}
