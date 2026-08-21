namespace MovieService.Application.Common.DTOs
{
    public record MovieActorDto(Guid MovieId, Guid ActorId, string CharacterName);
}
