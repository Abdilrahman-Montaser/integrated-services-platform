using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    public class LotImageConfiguration :IEntityTypeConfiguration <LotImage>
    {
        public void Configure (EntityTypeBuilder<LotImage> builder)
        {
            builder.ToTable("LotImage");
            builder.HasKey(i=> i.ImageId);
            builder.Property(i => i.ImageUrl)
              .IsRequired()
              .HasMaxLength(500);
            builder.Property(i => i.IsPrimary).HasDefaultValue(false);
            builder.Property(i => i.SortOrder).HasDefaultValue(0);
            // hasindex => عشان تروح لمكان معين 
            builder.HasIndex(i => i.LotId);
            // الجزء ده عشان يضمن صورة واحدة اساسية لكل lot
            builder.HasIndex(i => new { i.LotId, i.IsPrimary })
              .IsUnique()
              .HasFilter("[IsPrimary] = 1");
            
        }
            

    }
}
