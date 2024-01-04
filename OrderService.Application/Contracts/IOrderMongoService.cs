using OrderServise.Domain.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts
{
    public interface IOrderMongoService
    {
        Task CreateOrder(OrderMongo order);
    }
}
