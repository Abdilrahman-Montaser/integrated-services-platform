using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.ViewModels.Orders;

namespace TadweerHub.PL.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index(string? status)
        {
            ViewData["Filter"] = status ?? "all";
            return View(TempOrders.Cast<OrderRowVM>().ToList());
        }

        public IActionResult Details(int id)
        {
            var order = TempOrders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // داتا مؤقتة مطابقة للبروتوتايب لحد ما منتصر يحدّث MockData
        // (غير الطلب الأول، باقي تفاصيل السواق والعناوين أرقام تجريبية)
        private static readonly List<OrderDetailsVM> TempOrders = new()
        {
            R(1, "ORD-26-1187", "LOT-0409", "دنيم أزرق ١٢ أونصة", "#34506E", 3400, 61200, "transit", 2,
              new DateTime(2026, 11, 12, 10, 42, 0), "مصنع العاشر للدنيم",
              "دنيم أزرق ١٢ أونصة", 62, "العاشر من رمضان", "الجيزة — أبو رواش",
              "482913", "محمود ع.", 3385, "4821 ط ن ر", "+20 112 *** 4410",
              new DateTime(2026, 11, 12, 13, 5, 0), null),

            R(2, "ORD-26-1179", "LOT-0412", "قطن بوبلين أبيض", "#ECE6D8", 1250, 18750, "funded", 1,
              new DateTime(2026, 11, 11, 9, 15, 0), "مصنع النيل للنسيج",
              "قطن بوبلين أبيض", 15, "المحلة الكبرى", "الجيزة — أبو رواش",
              "392608", null, null, "—", "—", null, null),

            R(3, "ORD-26-1164", "LOT-0391", "قصاقيص قطن ملوّنة", "#C4962C", 2100, 12600, "completed", 3,
              new DateTime(2026, 11, 8, 11, 30, 0), "مصنع النيل للنسيج",
              "قصاقيص قطن ملوّنة", 20, "المحلة الكبرى", "الجيزة — أبو رواش",
              "175840", "كريم ف.", 2090, "6612 ب ع ن", "+20 100 *** 1822",
              new DateTime(2026, 11, 8, 14, 0, 0), new DateTime(2026, 11, 8, 18, 20, 0)),

            R(4, "ORD-26-1152", "LOT-0405", "بوليستر مخلوط عنابي", "#7E3434", 820, 9840, "disputed", 2,
              new DateTime(2026, 11, 5, 8, 50, 0), "شركة الفيروز للغزل",
              "بوليستر مخلوط عنابي", 10, "الإسكندرية", "الجيزة — أبو رواش",
              "841963", "ياسر ع.", 790, "3307 ص ل م", "+20 111 *** 9051",
              new DateTime(2026, 11, 5, 12, 10, 0), null),

            R(5, "ORD-26-1140", "LOT-0376", "جيرسيه أخضر زيتي", "#4F6E4A", 1100, 15400, "completed", 3,
              new DateTime(2026, 11, 2, 10, 5, 0), "شركة الفيروز للغزل",
              "جيرسيه أخضر زيتي", 14, "الإسكندرية", "الجيزة — أبو رواش",
              "507214", "كريم ف.", 1095, "6612 ب ع ن", "+20 100 *** 1822",
              new DateTime(2026, 11, 2, 13, 0, 0), new DateTime(2026, 11, 2, 17, 45, 0)),

            R(6, "ORD-26-1131", "LOT-0398", "كتان طبيعي خام", "#C6B186", 540, 13500, "completed", 3,
              new DateTime(2026, 10, 29, 9, 20, 0), "الدلتا للملابس الجاهزة",
              "كتان طبيعي خام", 8, "شبرا الخيمة", "الجيزة — أبو رواش",
              "260417", "محمود ع.", 538, "4821 ط ن ر", "+20 112 *** 4410",
              new DateTime(2026, 10, 29, 12, 30, 0), new DateTime(2026, 10, 29, 15, 10, 0)),
        };

        private static OrderDetailsVM R(
            int id, string no, string lotCode, string lotName, string hex,
            decimal kg, decimal price, string status, int step, DateTime date, string factory,
            string material, int rolls, string from, string to,
            string code, string? driver, decimal? weighed, string plate, string phone,
            DateTime? started, DateTime? completed)
        {
            var fee = 850m;
            var commission = Math.Round(price * 0.02m, 2);
            return new OrderDetailsVM
            {
                Id = id,
                OrderNo = no,
                LotCode = lotCode,
                LotName = lotName,
                ColorHex = hex,
                WeightKg = kg,
                LotPrice = price,
                PlatformCommission = commission,
                DeliveryFee = fee,
                Total = price + commission + fee,
                Status = status,
                Step = step,
                CreatedAt = date,
                Factory = factory,
                Workshop = "ورشة الأمل للخياطة",
                DriverName = driver,
                DeliveryCode = code,
                Material = material,
                RollsCount = rolls,
                FromAddress = from,
                ToAddress = to,
                WeighedKg = weighed,
                VehiclePlate = plate,
                DriverPhone = phone,
                StartedAt = started,
                CompletedAt = completed,
                EscrowNo = "E-" + (77119 + id)
            };
        }


    }
}
