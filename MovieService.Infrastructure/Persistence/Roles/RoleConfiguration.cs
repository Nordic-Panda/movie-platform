using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Roles;

namespace MovieService.Infrastructure.Persistence.Roles
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).IsRequired().HasMaxLength(RoleRules.NameMaxLength);
            entity.HasIndex(x => x.Name).IsUnique();

            entity.Property(x => x.Code).IsRequired().HasMaxLength(RoleRules.CodeMaxLength);
            entity.HasIndex(x => x.Code).IsUnique();

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
