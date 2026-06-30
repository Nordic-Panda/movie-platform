using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Entities;
using MovieService.Domain.Movies;
namespace MovieService.Infrastructure.Persistence.MovieActors
{
    internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        void IEntityTypeConfiguration<MovieActor>.Configure(EntityTypeBuilder<MovieActor> entity)
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
        }
    }
}
