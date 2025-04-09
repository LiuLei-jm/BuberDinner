using BuberDinner.Domain.User;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
            id => id.Value,
            value => UserId.Create(value)
            );
        builder.Property(user => user.FirstName).HasMaxLength(100);
        builder.Property(user => user.LastName).HasMaxLength(100);
        builder.Property(user => user.Email).HasMaxLength(100);
        builder.Property(user => user.Password).HasMaxLength(100);
    }
}
