using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Lots;
using TadweerHub.PL.ViewModels.Wallets;

namespace TadweerHub.PL.Controllers;

public class FactoryController : Controller
{
    private const string CurrentFactory = "مصنع النيل للنسيج";

    [HttpGet]
    public IActionResult Dashboard()
    {
        var myLots = MockData.Lots.Where(l => l.Factory == CurrentFactory).ToList();
        var myOrders = MockData.Orders.Where(o => o.Factory == CurrentFactory).ToList();

        ViewBag.LotsCount = myLots.Count;
        ViewBag.ActiveLots = myLots.Count(l => l.Status == "active");
        ViewBag.TotalSales = myOrders.Where(o => o.Status == "completed").Sum(o => o.LotPrice - o.PlatformCommission);
        ViewBag.PendingPayout = myOrders.Where(o => o.Status is "funded" or "transit").Sum(o => o.LotPrice - o.PlatformCommission);
        ViewBag.SavedKg = myOrders.Where(o => o.Status == "completed").Sum(o => o.WeightKg) + 4200m;

        return View(myOrders);
    }

    [HttpGet]
    public IActionResult Lots()
    {
        var myLots = MockData.Lots.Where(l => l.Factory == CurrentFactory).ToList();
        return View(myLots);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PublishLot(string code)
    {
        var lot = MockData.Lots.FirstOrDefault(l => l.Code == code && l.Factory == CurrentFactory);
        if (lot != null && lot.Status == "draft")
        {
            lot.Status = "active";
            TempData["Success"] = $"تم نشر اللوط {code} في السوق بنجاح.";
        }
        return RedirectToAction(nameof(Lots));
    }

    [HttpGet]
    public IActionResult CreateLot()
    {
        return View(new LotCardVM
        {
            Governorate = "المحلة الكبرى",
            ColorHex = "#2F5D3A",
            ColorName = "أخضر غامق",
            Condition = "بواقي قص — جديد"
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateLot(LotCardVM model, string submitAction)
    {
        if (string.IsNullOrWhiteSpace(model.Name) || model.WeightKg <= 0 || model.Price <= 0)
        {
            TempData["Error"] = "من فضلك أدخل اسم اللوط والوزن والسعر بشكل صحيح.";
            return View(model);
        }

        var code = $"LOT-{Random.Shared.Next(420, 999):D4}";
        model.Code = code;
        model.Factory = CurrentFactory;
        model.Status = submitAction == "draft" ? "draft" : "active";
        model.IsLight = model.ColorHex.ToUpperInvariant() is "#ECE6D8" or "#C6B186" or "#FFFFFF" or "#F6F1E7";

        MockData.Lots.Insert(0, model);
        TempData["Success"] = model.Status == "draft"
            ? $"تم حفظ اللوط ({code}) كمسودة."
            : $"تم نشر اللوط ({code}) في السوق بنجاح.";

        return RedirectToAction(nameof(Lots));
    }

    [HttpGet]
    public IActionResult Orders()
    {
        var myOrders = MockData.Orders.Where(o => o.Factory == CurrentFactory).ToList();
        return View(myOrders);
    }
}