namespace MovieService.Application.Common.DTOs
{
    public record MovieCastDto(
        Guid ActorId,
        string FirstName,
        string LastName,
        int BirthYear,
        string CharacterName,
        bool IsMainCast
    );
}
