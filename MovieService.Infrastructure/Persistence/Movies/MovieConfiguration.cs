using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Movies;
using MovieService.Infrastructure.Rules;

namespace MovieService.Infrastructure.Persistence.Movies
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title).IsRequired().HasMaxLength(DbMovieRules.TitleMaxLength);

            // Create a MovieGenres join table for the many-to-many relationship between Movie and Genre
            // Reason why this is different than MovieActor which is also a joint table is because
            // MovieActor has additional properties Charactername etc while MovieGenres does not have any additional properties
            entity.HasMany(x => x.Genres).WithMany().UsingEntity("MovieGenres");

            entity.Property(x => x.Year).IsRequired();

            entity
                .HasOne(x => x.Language)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entity.OwnsOne(
                x => x.Details,
                details =>
                {
                    details.Property(d => d.Synopsis).HasMaxLength(DbMovieRules.SynopsisMaxLength);

                    details.OwnsOne(
                        d => d.Budget,
                        money =>
                        {
                            money
                                .Property(m => m.Amount)
                                // 18 = total digits
                                // 2 = digits after the decimal point
                                .HasPrecision(18, 2);

                            // EFcore would create relation by itself, so this has ForeignKey is not need
                            // but this indicates we want the "shadow FK" to be called this string.
                            money
                                .HasOne(m => m.Currency)
                                .WithMany()
                                .HasForeignKey("CurrencyId")
                                .IsRequired()
                                .OnDelete(DeleteBehavior.Restrict);
                        }
                    );
                }
            );

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
