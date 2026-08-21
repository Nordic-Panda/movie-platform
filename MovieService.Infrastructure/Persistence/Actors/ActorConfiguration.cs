using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Actors;

namespace MovieService.Infrastructure.Persistence.Actors
{
    internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName).IsRequired();

            entity.Property(x => x.LastName).IsRequired();

            entity.Property(x => x.BirthYear).IsRequired();

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
