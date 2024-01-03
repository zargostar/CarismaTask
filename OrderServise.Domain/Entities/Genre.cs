using OrderServise.Domain.Common;

namespace OrderServise.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<GenreMovie> GenreMovie { get; set; }

    }
}
