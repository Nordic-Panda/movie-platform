using MovieService.Application.Common.DTOs;
using MovieService.Domain.Reviews;

namespace MovieService.Application.Common.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToDto(Review review) 
        {
            return new ReviewDto(review.Id, review.MovieId, review.Comment, review.Rating);
        
        }
    }
}
