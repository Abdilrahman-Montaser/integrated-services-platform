namespace TadweerHub.PL.ViewModels.Wallets
{
    public class WalletIndexVM
    {
        public WalletSummaryVM Summary { get; set; } = new();
        public List<WalletTransactionVM> Transactions { get; set; } = new();
    }
}
