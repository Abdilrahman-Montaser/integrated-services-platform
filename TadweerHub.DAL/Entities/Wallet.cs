namespace TadweerHub.DAL.Entities
{
    public class Wallet
    {
        public int WalletId { get; set; }

        public int UserId { get; set; }

        public decimal AvailableBalance { get; set; }
        public decimal HeldBalance { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public User User { get; set; } = null!;
        public ICollection<WalletTransaction> Transactions { get; set; }
            = new List<WalletTransaction>();
    }
}
