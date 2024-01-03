using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class ActorMovie
    {
        public string Role { get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
