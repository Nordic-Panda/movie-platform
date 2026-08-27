using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Settings;
using MovieService.Domain.Auth;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Auth
{
    public class GoogleAuthenticationProvider : IExternalAuthenticationProvider
    {
        private readonly GoogleSettings _settings;

        public string Provider => IdentityProviders.Google;

        public GoogleAuthenticationProvider(IOptions<GoogleSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<ExternalIdentity> AuthenticateAsync(
            string credential,
            CancellationToken cancellationToken
        )
        {
            if (string.IsNullOrWhiteSpace(credential))
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );

            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(
                    credential,
                    new GoogleJsonWebSignature.ValidationSettings
                    {
                        Audience = new[] { _settings.ClientId },
                    }
                );

                if (string.IsNullOrWhiteSpace(payload.Subject))
                {
                    throw new UnauthorizedException(
                        UserErrors.CredentialInvalidCode,
                        UserErrors.CredentialInvalidMessage
                    );
                }

                return new ExternalIdentity(
                    IdentityProviders.Google,
                    payload.Subject,
                    payload.Email,
                    payload.Name
                );
            }
            // Tho ExceptionMiddleware handles exceptions for the entire request,
            // converting the third-party exception here prevents InvalidJwtException
            // from leaking into ExceptionMapper.
            // This keeps ExceptionMapper independent of Google-specific exceptions.
            // #separation of concerns / dependency boundary
            catch (InvalidJwtException)
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }
        }
    }
}
