using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Theaters.Dtos
{
    public class TheaterDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
