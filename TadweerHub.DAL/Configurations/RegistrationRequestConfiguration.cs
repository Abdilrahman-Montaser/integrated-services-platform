using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations;

public class RegistrationRequestConfiguration : IEntityTypeConfiguration<RegistrationRequest>
{
    public void Configure(EntityTypeBuilder<RegistrationRequest> builder)
    {
        builder.ToTable("RegistrationRequests");

        builder.HasKey(r => r.RequestId);

        builder.Property(r => r.RequestNo).IsRequired().HasMaxLength(30);
        builder.HasIndex(r => r.RequestNo).IsUnique();

      
        builder.Property(r => r.Status)
               .IsRequired()
               .HasMaxLength(20)
               .HasConversion<string>()
               .HasDefaultValue(RegistrationStatus.Pending);

        builder.Property(r => r.SubmittedAt).IsRequired();
        builder.Property(r => r.RejectReason).HasMaxLength(500);

        builder.HasIndex(r => r.Status);
        builder.HasIndex(r => r.UserId);

       
        builder.HasOne(r => r.User)
               .WithMany()
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasOne(r => r.Reviewer)
               .WithMany()
               .HasForeignKey(r => r.ReviewedBy)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
