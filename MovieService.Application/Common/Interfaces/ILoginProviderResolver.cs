namespace MovieService.Application.Common.Interfaces
{
    public interface ILoginProviderResolver
    {
        ILoginProvider Resolve(string provider);
    }
}
