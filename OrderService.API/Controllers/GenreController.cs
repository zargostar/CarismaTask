using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Genres.Comands;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using OrderServise.Domain.Common;
using System.Data;

namespace OrderService.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = UserRole.ADMIN)]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator mediator;

        public GenreController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize(Policy = "IsOperator")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGenreCommand createGenre)
        {
            await mediator.Send(createGenre);
            return NoContent();
        }
        [Authorize()]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetGenreQuery(id);
            var genre= await mediator.Send(query);
            return Ok(genre);
        }
    }
}
