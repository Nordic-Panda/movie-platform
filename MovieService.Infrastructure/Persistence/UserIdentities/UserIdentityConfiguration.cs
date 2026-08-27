using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Persistence.UserIdentities
{
    internal class UserIdentityConfiguration : IEntityTypeConfiguration<UserIdentity>
    {
        void IEntityTypeConfiguration<UserIdentity>.Configure(
            EntityTypeBuilder<UserIdentity> entity
        )
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.UserId).IsRequired();

            entity.Property(x => x.PasswordHash).IsRequired(false);

            entity.Property(x => x.CreatedAt).IsRequired();

            entity
                .Property(x => x.Provider)
                .IsRequired()
                .HasMaxLength(UserIdentityRules.UserIdentityProviderMaxLength);

            entity
                .Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(UserIdentityRules.UserIdentitySubjectMaxLength);

            // An identity from the same provider can only belong
            // to one user.
            entity.HasIndex(x => new { x.Provider, x.Subject }).IsUnique();

            entity
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
