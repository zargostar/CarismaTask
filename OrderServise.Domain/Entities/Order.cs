using OrderService.Application.Exceptions;
using OrderServise.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Order()
        {
            
        }
        public Order(string userId, string fullName, string address, string moblie)
        {
            UserId = userId;
            FullName = fullName;
            Address = address;
            Moblie = moblie;
        }

        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Moblie { get; set; }
        public List<OrderItem> Items { get; set;} = new List<OrderItem>();
        public void CheckMinimumPrice()
        {
            int total=Items.Sum(item=>item.Count*item.Price);
            if(total < 5000) {
                throw new ClientErrorMessage("حداقل مبلغ کل سفارش باید ار 5000 بیشتر باشد");
            }

        }
        public void CheckValidOrderTime()
        {
            int orderTime = DateTime.Now.Hour;
            if(orderTime <8 || orderTime > 18) {
                throw new ClientErrorMessage("فروشگاه تعطیل است");
            }
        }
    }
}
