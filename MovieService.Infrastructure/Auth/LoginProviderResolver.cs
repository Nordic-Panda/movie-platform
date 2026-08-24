using MovieService.Application.Common.Interfaces;
using MovieService.Domain.Auth;
using MovieService.Domain.Common.Exceptions;

namespace MovieService.Infrastructure.Auth
{
    public class LoginProviderResolver : ILoginProviderResolver
    {
        private readonly IReadOnlyDictionary<string, ILoginProvider> _providers;

        public LoginProviderResolver(IEnumerable<ILoginProvider> providers)
        {
            _providers = providers.ToDictionary(x => x.Provider, StringComparer.OrdinalIgnoreCase);
        }

        public ILoginProvider Resolve(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new DomainException(
                    AuthErrors.ProviderRequiredCode,
                    AuthErrors.ProviderRequiredMessage
                );
            }

            if (!_providers.TryGetValue(provider, out var loginProvider))
            {
                throw new DomainException(
                    AuthErrors.UnsupportedProviderCode,
                    AuthErrors.UnsupportedProviderMessage
                );
            }

            return loginProvider;
        }
    }
}
