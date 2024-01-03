using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Movies.Comands;
using OrderService.Application.Features.Movies.Queries.GetMovieById;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieCommand movie)
        {
            await mediator.Send(movie);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetMovieByIdQuery(id);
           var result= await mediator.Send(query);
            return Ok(result);
        }
    }
}
