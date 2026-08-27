using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Domain.Auth;

namespace MovieService.Infrastructure.Auth
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

        public Guid UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(
                    ClaimTypes.NameIdentifier
                );

                if (!Guid.TryParse(userId, out var id))
                    throw new UnauthorizedException(
                        AuthErrors.CurrentUserIdMissingOrInvalidCode,
                        AuthErrors.CurrentUserIdMissingOrInvalidMessage
                    );

                return id;
            }
        }
    }
}
