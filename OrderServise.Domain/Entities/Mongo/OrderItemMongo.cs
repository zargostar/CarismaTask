using MongoDB.Bson.Serialization.Attributes;

namespace OrderServise.Domain.Entities.Mongo
{
    public class OrderItemMongo
    {
      
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
