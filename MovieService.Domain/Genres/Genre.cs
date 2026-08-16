namespace MovieService.Domain.Genres
{
    public class Genre
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Genre() { }

        internal Genre(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
