using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Orders;
using TadweerHub.PL.ViewModels.Wallets;

namespace TadweerHub.PL.Controllers;

public class LotsController : Controller
{
    [HttpGet]
    public IActionResult Index(string? material, string? governorate, decimal? maxPrice, string? q)
    {
        var query = MockData.Lots.Where(l => l.Status == "active");

        if (!string.IsNullOrWhiteSpace(material))
            query = query.Where(l => l.Material == material);

        if (!string.IsNullOrWhiteSpace(governorate))
            query = query.Where(l => l.Governorate == governorate);

        if (maxPrice.HasValue && maxPrice.Value > 0)
            query = query.Where(l => l.Price <= maxPrice.Value);

        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(l => l.Name.Contains(q, StringComparison.OrdinalIgnoreCase)
                                  || l.Code.Contains(q, StringComparison.OrdinalIgnoreCase)
                                  || l.Factory.Contains(q, StringComparison.OrdinalIgnoreCase));

        ViewBag.Materials = MockData.Lots.Select(l => l.Material).Distinct().ToList();
        ViewBag.Governorates = MockData.Lots.Select(l => l.Governorate).Distinct().ToList();
        ViewBag.SelectedMaterial = material;
        ViewBag.SelectedGov = governorate;
        ViewBag.MaxPrice = maxPrice;
        ViewBag.Query = q;

        return View(query.ToList());
    }

    [HttpGet]
    public IActionResult Details(string id)
    {
        var lot = MockData.Lots.FirstOrDefault(l =>
            string.Equals(l.Code, id, StringComparison.OrdinalIgnoreCase));

        if (lot == null) return NotFound();

        ViewBag.WalletAvailable = MockData.Wallet.Available;
        return View(lot);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Buy(string code, string deliveryAddress)
    {
        var lot = MockData.Lots.FirstOrDefault(l => l.Code == code);
        if (lot == null) return NotFound();

        const decimal deliveryFee = 350m; // تقدير مسافة افتراضي 50 كم (100 + 5*50)
        var total = lot.Price + deliveryFee;

        if (MockData.Wallet.Available < total)
        {
            TempData["Error"] = "رصيدك المتاح غير كافٍ لإتمام حجز الضمان. اشحن محفظتك أولاً.";
            return RedirectToAction(nameof(Details), new { id = code });
        }

        // حجز المبلغ في الضمان وتحديث حالة اللوط
        MockData.Wallet.Available -= total;
        MockData.Wallet.Held += total;
        lot.Status = "reserved";

        var orderNo = $"ORD-{Random.Shared.Next(1050, 1999)}";
        MockData.WalletTransactions.Insert(0, new WalletTransactionVM
        {
            Date = DateTime.Now,
            Description = $"حجز ضمان لطلب شراء ({lot.Code})",
            OrderNo = orderNo,
            Amount = -total,
            Status = "funded"
        });

        MockData.Orders.Insert(0, new OrderRowVM
        {
            Id = MockData.Orders.Count + 1,
            OrderNo = orderNo,
            LotCode = lot.Code,
            LotName = lot.Name,
            ColorHex = lot.ColorHex,
            WeightKg = lot.WeightKg,
            LotPrice = lot.Price,
            DistanceKm = 50,
            DeliveryFee = deliveryFee,
            PlatformCommission = Math.Round(lot.Price * 0.02m, 2),
            Total = total,
            Status = "funded",
            Step = 1,
            CreatedAt = DateTime.Now,
            Factory = lot.Factory,
            Workshop = "ورشة النور",
            DeliveryCode = Random.Shared.Next(100000, 999999).ToString()
        });

        return RedirectToAction("Index", "Orders");
    }
}