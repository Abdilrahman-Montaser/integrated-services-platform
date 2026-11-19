namespace TadweerHub.PL.ViewModels.Wallets;

public class WalletSummaryVM
{
    public decimal Available { get; set; }   // الرصيد المتاح
    public decimal Held { get; set; }        // المحجوز في الضمان
    public decimal Total => Available + Held;
}
