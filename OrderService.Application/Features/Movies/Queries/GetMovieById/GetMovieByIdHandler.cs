using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IMovirRepository movirRepository;
        private readonly IMapper mapper;
        public GetMovieByIdHandler(IMovirRepository movirRepository, IMapper mapper)
        {
            this.movirRepository = movirRepository;
            this.mapper = mapper;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
           var movie= await movirRepository.GetMovieById(request.Id);
          //  var movie = await movirRepository.GetAsync(x=>x.Id==request.Id,null,p=>p.);
           // return mapper.Map<MovieDto>(movie);
            return mapper.Map<MovieDto>(movie) ;
        }
    }
}
