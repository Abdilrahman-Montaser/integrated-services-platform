using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    public class DeliveryConfigurations : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d => d.OrderId);
            builder.Property(d => d.OrderId).ValueGeneratedNever();

            builder.Property(d => d.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(DeliveryStatus.Assigned);

            builder.Property(d => d.DeliveryCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.FailedAttempts)
                .HasDefaultValue(0);

            builder.Property(d => d.WeighedKg)
                .HasPrecision(18, 3);

            builder.Property(d => d.WeighbridgeImageUrl)
                .HasMaxLength(500);

            builder.Property(d => d.AssignedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(d => d.Order)
                   .WithOne(o => o.Delivery)
                   .HasForeignKey<Delivery>(d => d.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Driver)
                   .WithMany(dr => dr.Deliveries)
                   .HasForeignKey(d => d.DriverId)
                   .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
