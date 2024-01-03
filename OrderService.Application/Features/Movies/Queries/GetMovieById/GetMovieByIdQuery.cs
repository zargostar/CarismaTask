using MediatR;
using OrderService.Application.Features.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery:IRequest<MovieDto>
    {
        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
