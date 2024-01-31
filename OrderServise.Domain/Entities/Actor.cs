using OrderServise.Domain.Common;

namespace OrderServise.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public List<ActorMovie>?  ActorMovies { get; set; }

    }
}
