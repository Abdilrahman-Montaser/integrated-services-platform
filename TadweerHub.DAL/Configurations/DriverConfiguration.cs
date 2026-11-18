using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations;

public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder.ToTable("Workshops");

        builder.HasKey(w => w.UserId);
        builder.Property(w => w.UserId).ValueGeneratedNever();

        builder.Property(w => w.WorkshopName).IsRequired().HasMaxLength(200);
        builder.Property(w => w.Governorate).IsRequired().HasMaxLength(100);
        builder.Property(w => w.Address).IsRequired().HasMaxLength(500);

        builder.HasOne(w => w.User)
               .WithOne()
               .HasForeignKey<Workshop>(w => w.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
