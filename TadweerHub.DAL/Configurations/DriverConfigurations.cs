using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;


namespace TadweerHub.DAL.Configurations
{
    internal class DriverConfigurations : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(d=>d.user_id);
            builder.Property(d => d.user_id)
                .ValueGeneratedNever();

            builder.Property(d => d.governorate)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Vehicle_Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Plate_number)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(d => d.Plate_number)
                .IsUnique();

            builder.HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Driver>(d => d.user_id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
