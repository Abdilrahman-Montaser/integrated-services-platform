using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Wallets;

namespace TadweerHub.PL.Controllers
{
    public class WalletController : Controller
    {
        public IActionResult Index()
        {
            var vm = new WalletIndexVM
            {
                Summary = MockData.Wallet,
                Transactions = MockData.WalletTransactions
            };
            return View(vm);
        }
    }
}
