using MongoDB.Bson.Serialization.Attributes;
using OrderService.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities.Mongo
{
    public class OrderMongo
    {
       
        [BsonId]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Moblie { get; set; }
        public List<OrderItemMongo> Items { get; set; } = new List<OrderItemMongo>();



    }
}
