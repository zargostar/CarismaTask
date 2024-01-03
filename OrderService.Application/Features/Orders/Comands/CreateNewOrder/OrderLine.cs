using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Comands.CreateNewOrder
{
   
        public class OrderLine
        {
            public int ProductId { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
            //public int Price { get; set; }

    }
   
}
