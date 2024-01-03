using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class MovieTheater
    {
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }    
    }
}
