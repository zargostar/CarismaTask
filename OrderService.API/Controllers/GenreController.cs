using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Genres.Comands;
using OrderService.Application.Features.Genres.Queries.Getgenre;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator mediator;

        public GenreController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGenreCommand createGenre)
        {
            await mediator.Send(createGenre);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetGenreQuery(id);
            var genre= await mediator.Send(query);
            return Ok(genre);
        }
    }
}
