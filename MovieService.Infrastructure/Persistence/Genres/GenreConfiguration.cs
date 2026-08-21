using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Genres;

namespace MovieService.Infrastructure.Persistence.Genres
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).IsRequired().HasMaxLength(GenreRules.NameMaxLength);

            entity.HasIndex(x => x.Name).IsUnique();

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
