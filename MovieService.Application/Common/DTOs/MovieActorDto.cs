namespace MovieService.Application.Common.DTOs
{
    public record MovieActorDto
    (
        Guid Id,
        Guid MovieId,
        Guid ActorId,
        string CharacterName
    );
}
