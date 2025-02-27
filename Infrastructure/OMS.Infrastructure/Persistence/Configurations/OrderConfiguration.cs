using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMS.Domain.Entities;

namespace OMS.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreatedAt)
            .IsRequired();

        builder.Property(o => o.Description);

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        // Seed data
        builder.HasData(
            new Order { Id = 1, UserId = 1, CreatedAt = new DateTimeOffset(2025, 02, 27, 15, 0, 0, TimeSpan.Zero), Description = "لب تاپ Asus" },
            new Order { Id = 2, UserId = 2, CreatedAt = new DateTimeOffset(2024, 02, 27, 16, 5, 0, TimeSpan.Zero), Description = "گوشی موبایل Iphone 13" }
        );
    }
}