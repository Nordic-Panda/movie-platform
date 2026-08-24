using MovieService.Application.Common.DTOs;
using MovieService.Domain.Reviews;
using MovieService.Domain.Users;

namespace MovieService.Application.Common.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToDto(Review review, User user)
        {
            var displayName = user.IsActive ? user.DisplayName : UserErrors.InActiveUser;

            var username = user.IsActive ? user.Username : string.Empty;

            return new ReviewDto(
                review.Id,
                review.MovieId,
                review.Comment,
                review.Rating,
                displayName,
                username
            );
        }
    }
}
