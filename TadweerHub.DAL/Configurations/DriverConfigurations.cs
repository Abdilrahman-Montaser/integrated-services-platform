using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;


namespace TadweerHub.DAL.Configurations
{
    public class DriverConfigurations : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");

            builder.HasKey(d => d.UserId);
            builder.Property(d => d.UserId)
                .ValueGeneratedNever();

            builder.Property(d => d.Governorate)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.VehicleType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.PlateNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(d => d.PlateNumber)
                .IsUnique();

            builder.HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Driver>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
