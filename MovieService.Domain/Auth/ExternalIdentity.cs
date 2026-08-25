namespace MovieService.Domain.Auth
{
    public record ExternalIdentity(
        string Provider,
        string Subject,
        string Email,
        string DisplayName
    );
}
