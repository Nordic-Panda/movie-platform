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

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(DbMovieRules.TitleMaxLength);

            entity.Property(x => x.Genre)
                .IsRequired();

            entity.OwnsOne(x => x.Details, details =>
            {
                details.Property(d => d.Language)
                    .IsRequired()
                    .HasMaxLength(DbMovieRules.LanguageMaxLength);

                details.Property(d => d.Synopsis)
                    .HasMaxLength(DbMovieRules.SynopsisMaxLength);

                details.OwnsOne(d => d.Budget, money =>
                {
                    money.Property(m => m.Amount);
                    // 18 = total digits
                    // 2 = digits after the decimal point
                    //.HasPrecision(18, 2);
                    money.Property(m => m.Currency)
                        .HasMaxLength(DbMovieRules.CurrencyLength);
                });
            });
        }
    }
}
