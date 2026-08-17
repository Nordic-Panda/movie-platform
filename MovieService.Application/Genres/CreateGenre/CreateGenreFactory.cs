using MovieService.Domain.Genres;

namespace MovieService.Application.Genres.CreateGenre
{
    public static class CreateGenreFactory
    {
        public static Genre Create(CreateGenreCommand command)
        {
            return GenreFactory.Create(command.Name);
        }
    }
}
