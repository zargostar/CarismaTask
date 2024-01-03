using AutoMapper;
using OrderService.Application.Features.Genres.Comands;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class GenreMapping:Profile
    {
        public GenreMapping() { 
            CreateMap<CreateGenreCommand,Genre>();
            CreateMap<Genre, GenreDto>().ReverseMap();
        }

    }
}
