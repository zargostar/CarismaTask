using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Movies.Comands
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieCommand>
    {
        private readonly IMovirRepository  movirRepository;
        private readonly IMapper  mapper;

        public CreateMovieHandler(IMovirRepository movirRepository, IMapper mapper)
        {
            this.movirRepository = movirRepository;
            this.mapper = mapper;
        }

        public async Task Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = mapper.Map<Movie>(request);
            movie.Image = "guyguuy";
            await movirRepository.AddAsync(movie);
        }
    }
}
