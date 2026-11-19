using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderNo).IsRequired().HasMaxLength(30);
            builder.HasIndex(o => o.OrderNo).IsUnique();

            builder.Property(o => o.WeightKg).HasPrecision(18, 3);
            builder.Property(o => o.LotPrice).HasPrecision(18, 2);
            builder.Property(o => o.PlatformCommission).HasPrecision(18, 2);
            builder.Property(o => o.DeliveryFee).HasPrecision(18, 2);
            builder.Property(o => o.DistanceKm).HasPrecision(18, 2);
            builder.Property(o => o.TotalAmount).HasPrecision(18, 2);

            builder.Property(o => o.DeliveryAddress).IsRequired().HasMaxLength(500);
            builder.Property(o => o.Status).HasDefaultValue(OrderStatus.Paid);
            builder.Property(o => o.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(o => o.Lot)
                   .WithMany()
                   .HasForeignKey(o => o.LotId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Workshop)
                   .WithMany()
                   .HasForeignKey(o => o.WorkshopId)
                   .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
