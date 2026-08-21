using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.Roles;

namespace MovieService.Infrastructure.Persistence.Users
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Email).IsRequired();

            entity.HasIndex(x => x.Email).IsUnique();

            entity.Property(x => x.PasswordHash).IsRequired();

            entity.Property(x => x.RoleId).IsRequired();
            // Though explicitly configure of this is not required
            // It is still good to have it for control, expecially OnDelete behavior
            entity
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(x => x.IsActive).IsRequired();
        }
    }
}
