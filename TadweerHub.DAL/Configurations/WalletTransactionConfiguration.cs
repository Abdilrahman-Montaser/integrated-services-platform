using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Configurations
{
    internal class WalletTransactionConfiguration
        : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.ToTable("WalletTransactions");
            builder.HasKey(t => t.TransactionId);
            builder.Property(t => t.Amount)
                .HasPrecision(18, 2)
                .IsRequired();
            builder.Property(t => t.Type)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.PaymentMethod)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(t => t.ExternalRef)
                .HasMaxLength(200);
            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();
            builder.HasIndex(t => t.WalletId);
            builder.HasIndex(t => t.OrderId);
            builder.HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
