using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    public class DeliveryConfigurations : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d => d.order_id);
            builder.Property(d => d.order_id).ValueGeneratedNever();

            builder.Property(d => d.status)
                .HasDefaultValue(DeliveryStatus.Assigned);

            builder.Property(d => d.delivery_code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.failed_attempts)
                .HasDefaultValue(0);

            builder.Property(d => d.weighed_kg)
                .HasPrecision(18, 3);

            builder.Property(d => d.weighbridge_image_url)
                .HasMaxLength(500);

            builder.Property(d => d.assigned_at)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(d => d.Order)
                   .WithOne(o => o.Delivery)
                   .HasForeignKey<Delivery>(d => d.order_id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Driver)
                   .WithMany(dr => dr.Deliveries)
                   .HasForeignKey(d => d.driver_id)
                   .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
