using AutoMapper;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderLine, OrderItem>().ReverseMap();
            CreateMap<OrderItemCommand, Order>().ReverseMap();
        }
    }
}
