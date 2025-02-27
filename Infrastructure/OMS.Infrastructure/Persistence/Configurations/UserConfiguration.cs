using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMS.Domain.Entities;

namespace OMS.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FullName)
            .HasMaxLength(30)
            .IsUnicode()
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(40)
            .IsRequired();

        // Seed data
        builder.HasData(
            new User { Id = 1, FullName = "علی رضایی", Email = "alirezaei@gmail.com" },
            new User { Id = 2, FullName = "حامد حسنی", Email = "hasani@yahoo.com" }
        );
    }
}
