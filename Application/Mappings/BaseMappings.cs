using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class BaseMappings: Profile
    {
        public BaseMappings() {
            CreateMap<Card, CardModel>().ReverseMap();
            CreateMap<Photo, PhotoModel>().ReverseMap();
        }
    }
}
