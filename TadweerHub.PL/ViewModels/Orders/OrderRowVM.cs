namespace TadweerHub.PL.ViewModels.Orders;

// بيانات الطلب (للجدول وصفحة التفاصيل)
public class OrderRowVM
{
    public int Id { get; set; }
    public string OrderNo { get; set; } = "";        // ORD-1042
    public string LotCode { get; set; } = "";
    public string LotName { get; set; } = "";
    public string ColorHex { get; set; } = "#C4962C";
    public decimal WeightKg { get; set; }

    public decimal LotPrice { get; set; }
    public decimal PlatformCommission { get; set; }  // بتتخصم من المصنع
    public decimal DeliveryFee { get; set; }         // 100 + 5 × المسافة
    public decimal DistanceKm { get; set; }
    public decimal Total { get; set; }               // سعر اللوط + أجر التوصيل (اللي الورشة بتدفعه)

    public string Status { get; set; } = "funded";   // funded | transit | completed | disputed
    public int Step { get; set; } = 1;               // 1 تم الدفع، 2 في الطريق، 3 تم التسليم
    public DateTime CreatedAt { get; set; }

    public string Factory { get; set; } = "";
    public string Workshop { get; set; } = "";
    public string? DriverName { get; set; }
    public string DeliveryCode { get; set; } = "";   // 6 أرقام: الورشة تشوفه والسائق يدخله
}
