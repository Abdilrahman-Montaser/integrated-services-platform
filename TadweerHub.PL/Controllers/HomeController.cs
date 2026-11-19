using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels;

namespace TadweerHub.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // أحدث 4 لوطات معروضة (من الداتا الوهمية لحد ما الداتابيز تجهز)
            var lots = MockData.Lots
                .Where(l => l.Status == "active")
                .Take(4)
                .ToList();

            return View(lots);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
