using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Actors;
using MovieService.Domain.MovieActors;
using MovieService.Domain.Movies;

namespace MovieService.Infrastructure.Persistence.MovieActors
{
    internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        void IEntityTypeConfiguration<MovieActor>.Configure(EntityTypeBuilder<MovieActor> entity)
        {
            entity.HasKey(x => new { x.MovieId, x.ActorId });

            entity.Property(x => x.MovieId).IsRequired();

            entity.Property(x => x.ActorId).IsRequired();

            entity.Property(x => x.CharacterName).IsRequired();

            entity
                .HasIndex(x => new
                {
                    x.MovieId,
                    x.ActorId,
                    x.CharacterName,
                })
                .IsUnique();

            // Configure the relationship between MovieActor and Movie.
            // MovieActor has no navigation property to Movie, so this relationship
            // is configured only through the foreign key MovieId.
            // Cascade is when a Movie is deleted, its related MovieActor records are also deleted.
            entity
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne<Actor>()
                .WithMany()
                .HasForeignKey(x => x.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
