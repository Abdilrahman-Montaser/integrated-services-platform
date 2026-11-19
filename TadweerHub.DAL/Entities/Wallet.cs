namespace TadweerHub.DAL.Entities
{
    internal class Wallet
    {
        public int WalletId { get; set; }

        public int UserId { get; set; }

        public decimal AvailableBalance { get; set; }

        public byte[] RowVersion { get; set; } = null!;

       
        public ICollection<WalletTransaction> Transactions { get; set; }
            = new List<WalletTransaction>();
    }
}
