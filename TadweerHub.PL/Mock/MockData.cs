using System.Globalization;
using TadweerHub.PL.ViewModels.Lots;
using TadweerHub.PL.ViewModels.Orders;
using TadweerHub.PL.ViewModels.Wallets;

namespace TadweerHub.PL.Mock
{
    // بيانات وهمية مشتركة بين كل الشاشات لحد ما الداتابيز تجهز.
    // ملاحظة: الملف ده بيعدّله Team Lead بس. لو محتاج حقل جديد، اطلبه.
    public static class MockData
    {
        // ---------- اللوطات (المعروضة في السوق) ----------
        public static readonly List<LotCardVM> Lots = new()
        {
            L("LOT-0412", "قطن بوبلين أبيض",      "قطن",     1250, 18750, "المحلة الكبرى",    "مصنع النيل للنسيج",       "#ECE6D8", "بواقي قص — جديد", "أبيض عاجي",     15, light: true),
            L("LOT-0409", "دنيم أزرق ١٢ أونصة",    "جينز",    3400, 61200, "العاشر من رمضان",  "مصنع العاشر للدنيم",      "#34506E", "أطوال كاملة",     "أزرق نيلي",     40),
            L("LOT-0405", "بوليستر مخلوط عنابي",   "بوليستر",  820,  9840, "الإسكندرية",       "شركة الفيروز للغزل",      "#7E3434", "بواقي قص — جديد", "عنابي",         10),
            L("LOT-0398", "كتان طبيعي خام",        "كتان",     540, 13500, "شبرا الخيمة",      "الدلتا للملابس الجاهزة",  "#C6B186", "أطوال كاملة",     "بيج خام",        8, light: true),
            L("LOT-0391", "قصاقيص قطن ملوّنة",     "قطن",     2100, 12600, "المحلة الكبرى",    "مصنع النيل للنسيج",       "#C4962C", "قصاقيص مختلطة",   "ألوان مختلطة",   0),
            L("LOT-0387", "صوف رمادي فاتح",        "صوف",      960, 28800, "بورسعيد",          "شركة القناة للمنسوجات",   "#6E7472", "أطوال كاملة",     "رمادي",         12),
            L("LOT-0380", "فسكوز أسود ناعم",       "فسكوز",    700, 11200, "القاهرة",          "الدلتا للملابس الجاهزة",  "#2B2D2B", "بواقي قص — جديد", "أسود",           9),
            L("LOT-0376", "جيرسيه أخضر زيتي",      "قطن",     1100, 15400, "الجيزة",           "شركة الفيروز للغزل",      "#4F6E4A", "رولات ناقصة",     "أخضر زيتي",     14),
        };

        // ---------- الطلبات (طلبات ورشة النور) ----------
        // أجر التوصيل = 100 + 5 × المسافة | العمولة = 2% من سعر اللوط (على المصنع)
        // الإجمالي اللي بتدفعه الورشة = سعر اللوط + أجر التوصيل
        public static readonly List<OrderRowVM> Orders = new()
        {
            O(1, "ORD-1042", "LOT-0374", "قطن جبردين كحلي",   "#1A365D", 800,  18480, 100, "transit",   2, new DateTime(2026, 11, 15), "مصنع النيل للنسيج",     "محمود السيد", "841963"),
            O(2, "ORD-1038", "LOT-0366", "كانفاس قطني ثقيل",  "#B8532F", 1280, 44800,  45, "completed", 3, new DateTime(2026, 11, 5),  "مصنع العاشر للدنيم",    "كريم فاروق", "507214"),
            O(3, "ORD-1035", "LOT-0358", "كتان زيتي طبيعي",   "#3F5E4D", 876,  39420, 220, "funded",    1, new DateTime(2026, 11, 18), "الدلتا للملابس الجاهزة", null,          "392608"),
            O(4, "ORD-1029", "LOT-0349", "بوليستر أحمر قرمزي", "#8C2D19", 950,  23750,  30, "disputed",  2, new DateTime(2026, 11, 12), "شركة الفيروز للغزل",     "ياسر عادل",  "175840"),
        };

        // ---------- المحفظة (ورشة النور) ----------
        // المتاح 71,175 + المحجوز 83,700 (= الطلبات 1042 و 1035 و 1029)
        public static readonly WalletSummaryVM Wallet = new() { Available = 71175m, Held = 83700m };

        public static readonly List<WalletTransactionVM> WalletTransactions = new()
        {
            T(new DateTime(2026, 11, 18), "حجز ضمان لطلب شراء", "ORD-1035", -40620m,  "funded"),
            T(new DateTime(2026, 11, 15), "حجز ضمان لطلب شراء", "ORD-1042", -19080m,  "funded"),
            T(new DateTime(2026, 11, 12), "حجز ضمان لطلب شراء", "ORD-1029", -24000m,  "funded"),
            T(new DateTime(2026, 11, 9),  "إفراج الضمان للمصنع", "ORD-1038", -45125m,  "completed"),
            T(new DateTime(2026, 11, 5),  "حجز ضمان لطلب شراء", "ORD-1038", -45125m,  "completed"),
            T(new DateTime(2026, 11, 2),  "شحن رصيد",            null,       200000m, "completed"),
        };

        // ---------- دوال مساعدة لتقليل الكتابة ----------
        private static LotCardVM L(string code, string name, string material, decimal kg, decimal price,
            string gov, string factory, string hex, string condition, string colorName, int rolls,
            bool light = false, string status = "active") => new()
        {
            Code = code, Name = name, Material = material, WeightKg = kg, Price = price,
            Governorate = gov, Factory = factory, ColorHex = hex, Condition = condition,
            ColorName = colorName, RollsCount = rolls, IsLight = light, Status = status
        };

        private static OrderRowVM O(int id, string no, string lotCode, string lotName, string hex,
            decimal kg, decimal price, decimal km, string status, int step, DateTime date,
            string factory, string? driver, string code)
        {
            var fee = 100m + 5m * km;
            return new OrderRowVM
            {
                Id = id, OrderNo = no, LotCode = lotCode, LotName = lotName, ColorHex = hex,
                WeightKg = kg, LotPrice = price, DistanceKm = km, DeliveryFee = fee,
                PlatformCommission = Math.Round(price * 0.02m, 2),
                Total = price + fee,
                Status = status, Step = step, CreatedAt = date,
                Factory = factory, Workshop = "ورشة النور", DriverName = driver, DeliveryCode = code
            };
        }

        private static WalletTransactionVM T(DateTime date, string description, string? orderNo,
            decimal amount, string status) => new()
        {
            Date = date, Description = description, OrderNo = orderNo, Amount = amount, Status = status
        };
    }
}
