using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Settings;
using MovieService.Domain.Auth;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Auth
{
    public class ExternalRegistrationTokenService : IExternalRegistrationTokenService
    {
        private readonly JwtSettings _settings;

        public ExternalRegistrationTokenService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        // Goal here is to create a short-lived token for external first login registration.
        // Backend does not trust data frontend sends in, external identity data, such as provider subject email displayname etc
        // instead, using token that carries the identity data that was already validated by the external provider.
        public string CreateToken(ExternalIdentity identity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, identity.Subject),
                new Claim("provider", identity.Provider),
                new Claim(JwtRegisteredClaimNames.Email, identity.Email),
                new Claim("display_name", identity.DisplayName),
                new Claim("purpose", "external-registration"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExternalRegistrationExpiresInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ExternalIdentity ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateIssuer = true,
                ValidIssuer = _settings.Issuer,

                ValidateAudience = true,
                ValidAudience = _settings.Audience,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };

            try
            {
                var principal = new JwtSecurityTokenHandler().ValidateToken(
                    token,
                    validationParameters,
                    out _
                );

                var purpose = principal.FindFirst("purpose")?.Value;

                if (purpose != "external-registration")
                {
                    throw new UnauthorizedException(
                        UserErrors.CredentialInvalidCode,
                        UserErrors.CredentialInvalidMessage
                    );
                }

                var provider = principal.FindFirst("provider")?.Value;

                var subject = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

                var email = principal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

                var displayName = principal.FindFirst("display_name")?.Value;

                if (
                    string.IsNullOrWhiteSpace(provider)
                    || string.IsNullOrWhiteSpace(subject)
                    || string.IsNullOrWhiteSpace(email)
                    || string.IsNullOrWhiteSpace(displayName)
                )
                {
                    throw new UnauthorizedException(
                        UserErrors.CredentialInvalidCode,
                        UserErrors.CredentialInvalidMessage
                    );
                }

                return new ExternalIdentity(provider, subject, email, displayName);
            }
            catch (SecurityTokenException)
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }
        }
    }
}
