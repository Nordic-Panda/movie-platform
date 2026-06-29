using MovieService.Application.Movies.AddActorToMovie;

namespace MovieService.Application.Common.Mappers
{
    public static class MovieActorMapper
    {
        public static AddActorToMovieCommand ToAddActorToMovieCommand(Guid movieId, Guid actorId, string characterName) {
            return new AddActorToMovieCommand(movieId, actorId, characterName);
        }
    }
}
