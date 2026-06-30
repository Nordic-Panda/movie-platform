using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Actors;
using MovieService.Domain.Entities;
using MovieService.Domain.Movies;
using MovieService.Domain.Reviews;
using MovieService.Infrastructure.Rules;

namespace MovieService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<MovieActor> MovieActor => Set<MovieActor>();
    public DbSet<Review> Reviews => Set<Review>();

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
                    // 18 = total digits
                    // 2 = digits after the decimal point
                    //.HasPrecision(18, 2);
                    money.Property(m => m.Currency)
                        .HasMaxLength(DbMovieRules.CurrencyLength);
                });
            });
        });

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName)
                .IsRequired();

            entity.Property(x => x.LastName)
                .IsRequired();

            entity.Property(x => x.BirthYear)
                .IsRequired();
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.MovieId)
                .IsRequired();

            entity.Property(x => x.ActorId)
                .IsRequired();

            entity.Property(x => x.CharacterName)
                .IsRequired();

            entity.HasIndex(x => new { x.MovieId, x.ActorId, x.CharacterName })
                .IsUnique();

            // Cascade delete, on delete all Entity that has relation to this will be deleted

            entity.HasOne<Movie>()
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.MovieId)
                .IsRequired();

            entity.Property(x => x.Comment)
                .IsRequired();

            entity.Property(x => x.Rating)
                .IsRequired();

            entity.HasOne<Movie>()
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}