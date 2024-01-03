using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderService.Application.Features.Orders.Comands.DeleteOrder;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderItemCommand orderItem)
        {
         
           
            await _mediator.Send(orderItem);
          return NoContent();   
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderToDelete = new DeleteOrderCommand(id);
            await _mediator.Send(orderToDelete);
            return NoContent();
        }
    }
}
