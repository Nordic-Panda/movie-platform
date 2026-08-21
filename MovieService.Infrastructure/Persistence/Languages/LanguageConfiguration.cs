using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Languages;

namespace MovieService.Infrastructure.Persistence.Languages
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        void IEntityTypeConfiguration<Language>.Configure(EntityTypeBuilder<Language> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).IsRequired().HasMaxLength(LanguageRules.NameMaxLength);
            entity.HasIndex(x => x.Name).IsUnique();

            entity.Property(x => x.Code).IsRequired().HasMaxLength(LanguageRules.ISO6391Length);
            entity.HasIndex(x => x.Code).IsUnique();

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
