using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Admin;
using TadweerHub.PL.ViewModels.Orders;

namespace TadweerHub.PL.Controllers
{
    public class AdminDashboardVM
    {
        public int TotalOrder { get; set; }
        public decimal TotalSales { get; set; }
        public int PendingOrders { get; set; }
        public List<OrderRowVM> Orders { get; set; }
    }
    public class PendingAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string Status { get; set; }

    }
    public class AdminController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Dashboard()
        {
            var orders = MockData.Orders;
            //var vm = new AdminDashboardVM
            //{
            //    TotalOrder = orders.Count,
            //    TotalSales = orders.Sum(o => o.Total),
            //    PendingOrders = orders.Count(o => o.Status != " Completed"),
            //    Orders = orders
            //};
            return View(orders);
        }

        public IActionResult Accounts()
        {
            var accounts = new List<PendingAccountVM>
    {
        new() { Id = 1, Name = "مصنع الوادي للغزل والنسيج", Role = "factory", Governorate = "الغربية",
                Documents = { "سجل تجاري", "بطاقة ضريبية" }, SubmittedAt = new DateTime(2026, 11, 12, 9, 14, 0) },
        new() { Id = 2, Name = "شركة الفيروز للملابس", Role = "factory", Governorate = "الإسكندرية",
                Documents = { "سجل تجاري", "بطاقة ضريبية" }, SubmittedAt = new DateTime(2026, 11, 12, 8, 2, 0) },
        new() { Id = 3, Name = "ورشة يد مصرية", Role = "workshop", Governorate = "القاهرة",
                Documents = { "بطاقة هوية" }, SubmittedAt = new DateTime(2026, 11, 11, 21, 40, 0) },
        new() { Id = 4, Name = "أحمد سعيد", Role = "driver", Governorate = "الجيزة",
                Documents = { "رخصة قيادة", "رخصة مركبة" }, SubmittedAt = new DateTime(2026, 11, 11, 18, 25, 0) },
        new() { Id = 5, Name = "مصنع الشروق للتريكو", Role = "factory", Governorate = "القليوبية",
                Documents = { "سجل تجاري" }, MissingDocument = "البطاقة الضريبية",
                SubmittedAt = new DateTime(2026, 11, 11, 15, 10, 0) },
        new() { Id = 6, Name = "مشغل الصفا", Role = "workshop", Governorate = "الدقهلية",
                Documents = { "بطاقة هوية" }, SubmittedAt = new DateTime(2026, 11, 11, 11, 47, 0) },
        new() { Id = 7, Name = "كريم فتحي", Role = "driver", Governorate = "الشرقية",
                Documents = { "رخصة قيادة", "رخصة مركبة" }, SubmittedAt = new DateTime(2026, 11, 10, 22, 3, 0) },
    };

            return View(accounts);
        }


    }
}
