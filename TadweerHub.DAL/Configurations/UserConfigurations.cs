using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Role)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(u => u.Phone)
                .IsUnique();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue(UserStatus.Pending);

            builder.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
