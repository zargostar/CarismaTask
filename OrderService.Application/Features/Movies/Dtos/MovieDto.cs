using OrderService.Application.Features.Actors.Dto;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using OrderService.Application.Features.Theaters.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Movies.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string IsActive { get; set; }
        public string CreateAt { get; set; }
        public List<TheaterDto> Theaters { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
