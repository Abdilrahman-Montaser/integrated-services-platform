using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    public class MaterialTypeConfiguration : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.ToTable("MaterialType");
            builder.HasKey(m => m.MaterialTypeId);
            
            builder.Property(m => m.Name)
                .IsRequired()
               .HasMaxLength(100);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.Property(m => m.Co2PerTon).HasPrecision(18, 4);
            builder.Property(m => m.WaterLPerTon).HasPrecision(18, 4);
            // MaterialType 1 --- * Lots
            builder.HasMany(m => m.Lots)
                   .WithOne(l => l.MaterialType)
                   .HasForeignKey(l => l.MaterialTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
