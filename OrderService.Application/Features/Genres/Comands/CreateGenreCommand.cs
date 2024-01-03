using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Genres.Comands
{
    public class CreateGenreCommand:IRequest
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
