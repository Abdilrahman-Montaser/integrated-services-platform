using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations;

public class RegistrationDocumentConfiguration : IEntityTypeConfiguration<RegistrationDocument>
{
    public void Configure(EntityTypeBuilder<RegistrationDocument> builder)
    {
        builder.ToTable("RegistrationDocuments");

        builder.HasKey(d => d.DocumentId);

        builder.Property(d => d.DocType).IsRequired().HasMaxLength(50);
        builder.Property(d => d.FileUrl).IsRequired().HasMaxLength(500);
        builder.Property(d => d.UploadedAt).IsRequired();

        builder.HasIndex(d => d.RequestId);

        builder.HasOne(d => d.Request)
               .WithMany(r => r.Documents)
               .HasForeignKey(d => d.RequestId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
