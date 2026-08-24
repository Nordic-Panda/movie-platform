using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Actors;
using MovieService.Domain.Currencies;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.MovieActors;
using MovieService.Domain.Movies;
using MovieService.Domain.Reviews;
using MovieService.Domain.Roles;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<MovieActor> MovieActor => Set<MovieActor>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserIdentity> UserIdentities => Set<UserIdentity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
