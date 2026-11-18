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
            builder.HasKey(d => d.DisputeId);

            builder.Property(d => d.Reason)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(d => d.Resolution)
                .HasMaxLength(1000);

            builder.Property(d => d.Status)
                .HasDefaultValue(DisputeStatus.Open);
            builder.Property(d => d.OpenedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(d => d.Order)
                   .WithMany()
                   .HasForeignKey(d => d.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.OpenedByUser)
                   .WithMany()
                   .HasForeignKey(d => d.OpenedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
