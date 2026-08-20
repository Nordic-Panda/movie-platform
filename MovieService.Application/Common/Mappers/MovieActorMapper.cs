using MovieService.Application.Common.DTOs;
using MovieService.Application.Movies.AddActorToMovie;
using MovieService.Domain.MovieActors;

namespace MovieService.Application.Common.Mappers
{
    public static class MovieActorMapper
    {
        public static AddActorToMovieCommand ToAddActorToMovieCommand(
            Guid movieId,
            Guid actorId,
            string characterName
        )
        {
            return new AddActorToMovieCommand(movieId, actorId, characterName);
        }

        public static MovieActorDto ToDto(MovieActor movieActor)
        {
            return new MovieActorDto(
                movieActor.Id,
                movieActor.MovieId,
                movieActor.ActorId,
                movieActor.CharacterName
            );
        }
    }
}
