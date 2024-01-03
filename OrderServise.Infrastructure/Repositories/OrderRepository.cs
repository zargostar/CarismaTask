using Microsoft.EntityFrameworkCore;
using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepositoryAsync<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> GetOrderForUser(string UserId)
        {
            var data= await _dbContext.Orders.Include(x=>x.Items).FirstOrDefaultAsync(order=>order.UserId == UserId);
            return data;
        }

        //public Task GetOrderByUserId(string UserId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
