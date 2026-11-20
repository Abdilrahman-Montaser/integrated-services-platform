using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets");
            builder.HasKey(w => w.WalletId);
            builder.Property(w => w.AvailableBalance)
                .HasPrecision(18, 2)
                .IsRequired()
                 .HasDefaultValue(0m);
            builder.Property(w => w.HeldBalance)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasDefaultValue(0m);
            builder.Property(w => w.RowVersion)
                .IsRowVersion();
            builder.HasIndex(w => w.UserId)
                .IsUnique();

            builder.HasOne(w => w.User)
               .WithOne()
               .HasForeignKey<Wallet>(w => w.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}