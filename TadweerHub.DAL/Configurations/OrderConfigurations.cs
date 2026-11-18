using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.order_id);

            builder.Property(o => o.order_no).IsRequired().HasMaxLength(30);
            builder.HasIndex(o => o.order_no).IsUnique();   

            builder.Property(o => o.weight_kg).HasPrecision(18, 3);
            builder.Property(o => o.lot_price).HasPrecision(18, 2);
            builder.Property(o => o.platform_commission).HasPrecision(18, 2);
            builder.Property(o => o.delivery_fee).HasPrecision(18, 2);
            builder.Property(o => o.distance_km).HasPrecision(18, 2);
            builder.Property(o => o.total_amount).HasPrecision(18, 2);

            builder.Property(o => o.delivery_address).IsRequired().HasMaxLength(500);
            builder.Property(o => o.status).HasDefaultValue(OrderStatus.Paid);
            builder.Property(o => o.created_at).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(o => o.Lot)
                   .WithMany()
                   .HasForeignKey(o => o.lot_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Workshop)
                   .WithMany()
                   .HasForeignKey(o => o.workshop_id)
                   .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
