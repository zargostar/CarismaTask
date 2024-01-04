using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Comands.CreateNewOrder
{
    public class OrderItemCommand : IRequest
    {
   

        public string FullName { get; private set; }
        public string Address { get; private set; }
        public string Moblie { get; private set; }
        public OrderItemCommand( string fullName, string address, string moblie)
        {
           
            FullName = fullName;
            Address = address;
            Moblie = moblie;
        }
       // public string UserId { get; private set; }
        public List<OrderLine> Items { get; set; }

    }


}
