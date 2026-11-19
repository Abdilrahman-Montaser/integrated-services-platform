using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    internal class NotificationConfiguration
        : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(n => n.NotificationId);
            builder.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(n => n.IsRead)
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(n => n.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();
          builder.HasIndex(n => n.UserId);
        }
    }
}
