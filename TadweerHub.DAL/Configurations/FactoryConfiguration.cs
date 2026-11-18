using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations;

public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
    public void Configure(EntityTypeBuilder<Factory> builder)
    {
        builder.ToTable("Factories");

        builder.HasKey(f => f.UserId);
        builder.Property(f => f.UserId).ValueGeneratedNever();

        builder.Property(f => f.CompanyName).IsRequired().HasMaxLength(200);
        builder.Property(f => f.Governorate).IsRequired().HasMaxLength(100);
        builder.Property(f => f.Address).IsRequired().HasMaxLength(500);

        builder.HasOne(f => f.User)
               .WithOne()
               .HasForeignKey<Factory>(f => f.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
