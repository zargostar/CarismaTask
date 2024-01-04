using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using OrderService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.Persistance
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
       // private IConfiguration configuration;
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T>  mongoCollection;
        //private readonly IConfiguration configuration;

        public MongoRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["mongoDb"]);
            db = client.GetDatabase("Order");
            mongoCollection = db.GetCollection<T>(typeof(T).Name);
          
        }

        public IMongoCollection<T> GetCollection()
        {

            return mongoCollection;
        }
    }
}
