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

            return new ReviewDto(
                review.Id,
                review.MovieId,
                review.UserId,
                user.Username,
                displayName,
                review.Comment,
                review.Rating
            );
        }
    }
}
