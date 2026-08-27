using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Domain.Auth;
using MovieService.Domain.Common.Exceptions;

namespace MovieService.Infrastructure.Auth
{
    public class RegisterProviderResolver : IRegisterProviderResolver
    {
        private readonly IReadOnlyDictionary<string, IRegisterProvider> _providers;

        public RegisterProviderResolver(IEnumerable<IRegisterProvider> providers)
        {
            // Use the provider name as the dictionary key and the provider itself as the value.
            // Ignore casing when comparing string keys IN THE FUTURE
            // so "Local" and "local" are treated as the same key.
            _providers = providers.ToDictionary(x => x.Provider, StringComparer.OrdinalIgnoreCase);
        }

        public IRegisterProvider Resolve(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new DomainException(
                    AuthErrors.ProviderRequiredCode,
                    AuthErrors.ProviderRequiredMessage
                );
            }

            if (!_providers.TryGetValue(provider, out var registerProvider))
            {
                throw new DomainException(
                    AuthErrors.UnsupportedProviderCode,
                    AuthErrors.UnsupportedProviderMessage
                );
            }

            return registerProvider;
        }
    }
}
