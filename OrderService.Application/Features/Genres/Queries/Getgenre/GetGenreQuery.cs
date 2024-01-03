using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Genres.Queries.Getgenre
{
    public class GetGenreQuery:IRequest<GenreDto>
    {
        public GetGenreQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
       
    }
}
