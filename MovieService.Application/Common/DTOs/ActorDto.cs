namespace MovieService.Application.Common.DTOs
{
    public record ActorDto
    (
        Guid Id,
        string Firstname,
        string Lastname,
        int BirthYear
    );
}
