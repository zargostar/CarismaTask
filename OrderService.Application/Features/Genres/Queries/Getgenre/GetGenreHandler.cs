using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Genres.Queries.Getgenre
{
    public class GetGenreHandler : IRequestHandler<GetGenreQuery, GenreDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper mapper;
        private readonly IGenreRepository genreRepository;

        public GetGenreHandler(IMediator mediator, IGenreRepository genreRepository, IMapper mapper)
        {
            _mediator = mediator;
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public async Task<GenreDto> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await genreRepository.GetByIdAsync(request.Id);
            return mapper.Map<GenreDto>(genre);

        }
    }
}
