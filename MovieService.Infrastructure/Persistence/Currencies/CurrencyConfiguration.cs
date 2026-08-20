using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Currencies;

namespace MovieService.Infrastructure.Persistence.Currencies
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        void IEntityTypeConfiguration<Currency>.Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).IsRequired().HasMaxLength(CurrencyRules.NameMaxLength);
            entity.HasIndex(x => x.Name).IsUnique();

            entity.Property(x => x.Code).IsRequired().HasMaxLength(CurrencyRules.IsoCodeLength);
            entity.HasIndex(x => x.Code).IsUnique();

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
