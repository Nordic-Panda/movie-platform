using MovieService.Domain.Enums;

namespace MovieService.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public TimeSpan Duration {  get; set; }
        public Genre Genre { get; set; }

    }
}
