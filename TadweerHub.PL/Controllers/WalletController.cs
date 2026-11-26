using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Wallets;

namespace TadweerHub.PL.Controllers;

public class WalletController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Transactions = MockData.WalletTransactions;
        return View(MockData.Wallet);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Deposit(decimal amount)
    {
        if (amount > 0)
        {
            MockData.Wallet.Available += amount;
            MockData.WalletTransactions.Insert(0, new WalletTransactionVM
            {
                Date = DateTime.Now,
                Description = "شحن رصيد (تجريبي)",
                OrderNo = null,
                Amount = amount,
                Status = "completed"
            });
            TempData["Success"] = $"تم شحن {amount:N0} ج.م بنجاح في رصيدك المتاح.";
        }
        return RedirectToAction(nameof(Index));
    }
}