
using TadweerHub.DAL.Enums;
namespace TadweerHub.DAL.Entities
{
    public class WalletTransaction
    {
        public int TransactionId { get; set; }

        public int WalletId { get; set; }

        public int? OrderId { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public TransactionStatus Status { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string? ExternalRef { get; set; }
        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; }
        public Wallet Wallet { get; set; } = null!;
        public Order? Order { get; set; }
    }
}
