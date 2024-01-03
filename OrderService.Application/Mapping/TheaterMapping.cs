using AutoMapper;
using OrderService.Application.Features.Theaters.Dtos;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class TheaterMapping:Profile
    {
        public TheaterMapping() { 
            CreateMap<Theater,TheaterDto>().ReverseMap();
        }
    }
}
