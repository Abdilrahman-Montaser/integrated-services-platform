using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    public class DisputeConfigurations : IEntityTypeConfiguration<Disputes>
    {
        public void Configure(EntityTypeBuilder<Disputes> builder)
        {
            builder.HasKey(d => d.dispute_id);

            builder.Property(d => d.reason)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(d => d.resolution)
                .HasMaxLength(1000);

            builder.Property(d => d.status)
                .HasDefaultValue(DisputeStatus.Open);
            builder.Property(d => d.opened_at)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(d => d.Order)
                   .WithMany()
                   .HasForeignKey(d => d.order_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.OpenedByUser)
                   .WithMany()
                   .HasForeignKey(d => d.opened_by)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
