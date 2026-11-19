namespace TadweerHub.PL.ViewModels.Lots;

// بيانات كارت اللوط (بتظهر في الرئيسية والتصفّح)
public class LotCardVM
{
    public string Code { get; set; } = "";          // LOT-0412
    public string Name { get; set; } = "";
    public string Material { get; set; } = "";      // قطن، جينز...
    public string Condition { get; set; } = "";     // بواقي قص — جديد
    public string ColorName { get; set; } = "";
    public string ColorHex { get; set; } = "#C4962C";
    public bool IsLight { get; set; }               // لون فاتح؟ (عشان الحدود)
    public decimal WeightKg { get; set; }
    public int RollsCount { get; set; }
    public decimal Price { get; set; }              // السعر الإجمالي
    public string Governorate { get; set; } = "";
    public string Factory { get; set; } = "";
    public string Status { get; set; } = "active";  // active | reserved | sold | draft
}
