using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("Drivers");

        builder.HasKey(d => d.UserId);
        builder.Property(d => d.UserId).ValueGeneratedNever();

        builder.Property(d => d.Governorate).IsRequired().HasMaxLength(100);
        builder.Property(d => d.VehicleType).IsRequired().HasMaxLength(100);
        builder.Property(d => d.PlateNumber).IsRequired().HasMaxLength(50);

        builder.HasOne(d => d.User)
               .WithOne()
               .HasForeignKey<Driver>(d => d.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
