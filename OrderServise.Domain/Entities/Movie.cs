using OrderServise.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class Movie:BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string IsActive { get; set; }
        public string CreateAt { get; set; }
        public List<MovieTheater> MovieTheater { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
        public List<GenreMovie> GenreMovie { get; set; }
    }
}
