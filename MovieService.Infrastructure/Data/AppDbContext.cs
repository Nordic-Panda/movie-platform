using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Movies;
using MovieService.Infrastructure.Rules;

namespace MovieService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(entity =>
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
                    money.Property(m => m.Currency)
                        .HasMaxLength(DbMovieRules.CurrencyLength);
                });
            });
        });
    }
}