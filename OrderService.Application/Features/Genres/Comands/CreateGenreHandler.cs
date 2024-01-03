using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Genres.Comands
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand>
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper  mapper;

        public CreateGenreHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genres = mapper.Map<Genre>(request);
              await  genreRepository.AddAsync(genres);
           
        }
    }
}
