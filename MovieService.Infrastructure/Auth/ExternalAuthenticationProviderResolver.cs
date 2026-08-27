using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Domain.Auth;
using MovieService.Domain.Common.Exceptions;

namespace MovieService.Infrastructure.Auth
{
    public class ExternalAuthenticationProviderResolver : IExternalAuthenticationProviderResolver
    {
        private readonly IReadOnlyDictionary<string, IExternalAuthenticationProvider> _providers;

        public ExternalAuthenticationProviderResolver(
            IEnumerable<IExternalAuthenticationProvider> providers
        )
        {
            _providers = providers.ToDictionary(x => x.Provider, StringComparer.OrdinalIgnoreCase);
        }

        public IExternalAuthenticationProvider Resolve(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new DomainException(
                    AuthErrors.ProviderRequiredCode,
                    AuthErrors.ProviderRequiredMessage
                );
            }

            if (!_providers.TryGetValue(provider, out var authenticationProvider))
            {
                throw new DomainException(
                    AuthErrors.UnsupportedProviderCode,
                    AuthErrors.UnsupportedProviderMessage
                );
            }

            return authenticationProvider;
        }
    }
}
