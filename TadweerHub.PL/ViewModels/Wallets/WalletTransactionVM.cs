namespace TadweerHub.PL.ViewModels.Wallets;

public class WalletTransactionVM
{
    public DateTime Date { get; set; }
    public string Description { get; set; } = "";
    public string? OrderNo { get; set; }
    public decimal Amount { get; set; }              // موجب = دخل، سالب = خرج
    public string Status { get; set; } = "completed"; // completed | funded
}
