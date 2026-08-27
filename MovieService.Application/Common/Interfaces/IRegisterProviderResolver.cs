namespace MovieService.Application.Common.Interfaces
{
    public interface IRegisterProviderResolver
    {
        IRegisterProvider Resolve(string provider);
    }
}
