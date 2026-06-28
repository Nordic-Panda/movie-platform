using MovieService.Application.Common.DTOs;
using MovieService.Domain.Actors;

namespace MovieService.Application.Common.Mappers
{
    public static class ActorMapper
    {
        public static ActorDto ToDto(Actor actor)
        {

            return new ActorDto(
                actor.Id,
                actor.FirstName,
                actor.LastName,
                actor.BirthYear                
                
                );
        
        }
    }
}
