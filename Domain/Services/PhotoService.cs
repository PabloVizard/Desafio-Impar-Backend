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
    public class PhotoService : BaseService<Photo>, IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;
        public PhotoService(IPhotoRepository photoRepository, IMapper mapper) : base(photoRepository, mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }
    }
}
