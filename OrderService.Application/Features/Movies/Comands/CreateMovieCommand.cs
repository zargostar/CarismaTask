using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Features.Actors.Dto;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Movies.Comands
{
    public class CreateMovieCommand:IRequest
    {
        public string Title { get; set; }
       // public string Image { get; set; }
        //public IFormFile MoviePoster { get; set; }
        public string IsActive { get; set; }
        public string CreateAt { get; set; }
        public List<int> TheaterIds { get; set; }
        public List<ActorMovieDto> Actors { get; set; }
        public List<int> GenresIds { get; set; }
    }

}
