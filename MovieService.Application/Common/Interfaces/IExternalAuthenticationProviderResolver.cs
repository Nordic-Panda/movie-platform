namespace MovieService.Application.Common.Interfaces
{
    public interface IExternalAuthenticationProviderResolver
    {
        IExternalAuthenticationProvider Resolve(string provider);
    }
}
