using AutoMapper;
using Hangfire;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Exceptions;
using OrderServise.Domain.Entities;
using OrderServise.Domain.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Comands.CreateNewOrder
{
    public class CreateNewOrderHandler : IRequestHandler<OrderItemCommand>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderMongoService mongoService;
        private readonly IMapper mapper;

        public CreateNewOrderHandler(IOrderRepository orderRepository, IMapper mapper, IOrderMongoService mongoService)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.mongoService = mongoService;
        }



        public async Task Handle(OrderItemCommand request, CancellationToken cancellationToken)
        {
         
            string userId = "1";
            var userOrder =await orderRepository.GetOrderForUser(userId);
           
            if (userOrder is null)
            {
             
               var order=mapper.Map<Order>(request);
                order.UserId = userId;  
                order.CheckMinimumPrice();
                order.CheckValidOrderTime();
                await orderRepository.AddAsync(order);
            }
            else
            {
                // 
                mapper.Map(request, userOrder);
                userOrder.CheckMinimumPrice();
                userOrder.CheckValidOrderTime();
                await orderRepository.UpdateAsync(userOrder);
                //throw new ClientErrorMessage("این کاربر یک  سفارش دارد");
            }
           var mongoOrder= mapper.Map<OrderMongo>(request);
            mongoOrder.UserId = userId;
            BackgroundJob.Enqueue(() => mongoService.CreateOrder(mongoOrder));
            //await mongoService.CreateOrder(mongoOrder);
            
        }
    }
}
