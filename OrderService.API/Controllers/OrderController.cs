using AutoMapper;
using Azure.Core;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderService.Application.Features.Orders.Comands.DeleteOrder;
using OrderServise.Domain.Entities;

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
        public async Task<IActionResult> Post([FromBody] OrderItemCommand ordr)
        {


            // await _mediator.Send(orderItem);
           // var client = new BackgroundJobClient();
            if (ordr is not null)
            {
                await _mediator.Send(ordr);
                //  client.Enqueue<OrderItemCommand>((ordr) => hangStart(ordr));
             //  BackgroundJob.Enqueue(() => hangStart(ordr));
               // await _mediator.Send(ordr);
            }
          
          //  BackgroundJob.Enqueue();
          return NoContent();   
        }
        private async Task hangStart(OrderItemCommand orderItem)
        {
            var client = new BackgroundJobClient();
            await _mediator.Send(orderItem);
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
