using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    public class DisputeConfigurations : IEntityTypeConfiguration<Dispute>
    {
        public void Configure(EntityTypeBuilder<Dispute> builder)
        {
            builder.ToTable("Disputes");

            builder.HasKey(d => d.DisputeId);

            builder.Property(d => d.Reason)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(d => d.Resolution)
                .HasMaxLength(1000);

            builder.Property(d => d.Status)
                .HasConversion<string>()
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
