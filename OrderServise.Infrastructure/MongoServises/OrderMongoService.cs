using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using OrderServise.Domain.Entities.Mongo;
using OrderServise.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.MongoServises
{
    public class OrderMongoService : IOrderMongoService
    {
        private readonly IMongoRepository<OrderMongo> mongoDbContext;
        private readonly IMongoCollection<OrderMongo> mongoCollection;

        public OrderMongoService(IMongoRepository<OrderMongo> mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
            mongoCollection = mongoDbContext.GetCollection();
        }

        public async Task CreateOrder(OrderMongo order)
        {
           await mongoCollection.InsertOneAsync(order);
        }
    }
}
