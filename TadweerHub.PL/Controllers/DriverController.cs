using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Wallets;

namespace TadweerHub.PL.Controllers;

public class DriverController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var deliveries = MockData.Orders
            .Where(o => o.Status is "transit" or "funded" or "completed")
            .ToList();

        return View(deliveries);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelivery(int orderId, string deliveryCode, decimal? weighedKg)
    {
        var order = MockData.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null) return NotFound();

        if (!string.Equals(order.DeliveryCode, deliveryCode?.Trim(), StringComparison.Ordinal))
        {
            TempData["Error"] = $"كود التسليم غير صحيح للطلب {order.OrderNo}. اطلب الكود الصحيح من الورشة.";
            return RedirectToAction(nameof(Index));
        }

        // إتمام التسليم وتحرير مبلغ الضمان للمصنع
        order.Status = "completed";
        order.Step = 3;

        if (MockData.Wallet.Held >= order.Total)
            MockData.Wallet.Held -= order.Total;

        MockData.WalletTransactions.Insert(0, new WalletTransactionVM
        {
            Date = DateTime.Now,
            Description = "إفراج الضمان للمصنع بعد تأكيد السائق",
            OrderNo = order.OrderNo,
            Amount = -order.Total,
            Status = "completed"
        });

        TempData["Success"] = $"تم تأكيد تسليم الطلب {order.OrderNo} بنجاح وتحرير مبلغ {order.Total:N0} ج.م للمصنع!";
        return RedirectToAction(nameof(Index));
    }
}