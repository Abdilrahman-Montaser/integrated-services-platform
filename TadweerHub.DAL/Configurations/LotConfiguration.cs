using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.ToTable("Lots");
            builder.HasKey(l => l.LotId);
            builder.Property(l => l.LotCode)
               .IsRequired()
               .HasMaxLength(50);
            builder.HasIndex(l => l.LotCode).IsUnique();
            builder.Property(l => l.Title).IsRequired().HasMaxLength(200);
            builder.Property(l => l.Description).HasMaxLength(2000);
            builder.Property(l => l.Condition).IsRequired().HasMaxLength(50);
            builder.Property(l => l.ColorName).IsRequired().HasMaxLength(50);
            builder.Property(l => l.ColorHex).IsRequired().HasMaxLength(7);
            builder.Property(l => l.Governorate).IsRequired().HasMaxLength(100);
            builder.Property(l => l.PickupAddress).IsRequired().HasMaxLength(500);

            builder.Property(l => l.WeightKg).HasPrecision(18, 2);
            builder.Property(l => l.TotalPrice).HasPrecision(18, 2);
            builder.Property(l => l.Status)
              .HasConversion<string>() //Draft ,Active ,Reserved ,Sold
              .HasMaxLength(20)
              .IsRequired();

            builder.Property(l => l.IsDeleted).HasDefaultValue(false);
            builder.Property(l => l.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            //بتمنع ان يحصل تعديلين في نفس الوقت 
            builder.Property(l => l.RowVersion).IsRowVersion();
            builder.HasQueryFilter(l => !l.IsDeleted);
            builder.HasIndex(l => l.FactoryId);
            builder.HasIndex(l => l.MaterialTypeId);
            builder.HasIndex(l => new { l.Status, l.Governorate });

            builder.HasOne(l => l.Factory)
                   .WithMany(f => f.Lots)
                    .HasForeignKey(l => l.FactoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.LotImages)
              .WithOne(i => i.Lot)
              .HasForeignKey(i => i.LotId)
              .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(l => l.Orders)
            //       .WithOne(o => o.Lot)
            //       .HasForeignKey(o => o.LotId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
