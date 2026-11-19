using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets");
            builder.HasKey(w => w.WalletId);
            builder.Property(w => w.AvailableBalance)
                .HasPrecision(18, 2)
              .IsRequired();
            builder.Property(w => w.RowVersion)
                .IsRowVersion();
            builder.HasIndex(w => w.UserId)
                .IsUnique();
        }
    }
}