using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Movies;
using MovieService.Domain.Reviews;

namespace MovieService.Infrastructure.Persistence.Reviews
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        void IEntityTypeConfiguration<Review>.Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.MovieId).IsRequired();

            entity.Property(x => x.Comment).IsRequired();

            entity.Property(x => x.Rating).IsRequired().HasMaxLength(ReviewRules.MaxRating);

            entity
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
