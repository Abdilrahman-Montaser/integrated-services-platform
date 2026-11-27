using Microsoft.AspNetCore.Mvc;
using TadweerHub.BLL.Services.Interfaces;

using TadweerHub.PL.ViewModels.Admin;
using TadweerHub.PL.ViewModels.Orders;

namespace TadweerHub.PL.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        public IActionResult Dashboard()
        {
            var orders =  _adminServices.GetDashboardOrders();
            var OrderRows = orders.Select(o => new OrderRowVM
            {
                Id = o.OrderId,
                OrderNo = o.OrderNo,
                WeightKg = o.WeightKg,
                LotPrice = o.LotPrice,
                PlatformCommission = o.PlatformCommission,
                DeliveryFee = o.DeliveryFee,
                DistanceKm = o.DistanceKm,
                Total = o.TotalAmount,
                Status=o.Status.ToString().ToLower(),
                CreatedAt = o.CreatedAt,
                Workshop=o.Workshop?.ToString()??string.Empty
            }).ToList();
            return View(OrderRows);
        }

        public IActionResult Accounts()

        {
            var PendingRequest =  _adminServices.GetPendingAccounts();
            var account = PendingRequest.Select(r => new PendingAccountVM
            {
                Id = r.RequestId,
                Name = r.User?.FullName ?? string.Empty,
                Role = r.User?.Role.ToString().ToLower() ?? "",
                Governorate = "",
                Documents = r.Documents?.Select(d => d.DocType ?? " ").ToList() ?? new List<string>(),
                MissingDocument = null,

                SubmittedAt = r.SubmittedAt,

            }).ToList();
            return View(account);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            _adminServices.ApproveAccount(id);
            return RedirectToAction(nameof(Accounts));
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            _adminServices.RejectAccount(id);
            return RedirectToAction(nameof(Accounts));
        }
        //#region MyRegion
        ////        var accounts = new List<PendingAccountVM>
        ////{
        ////    new() { Id = 1, Name = "مصنع الوادي للغزل والنسيج", Role = "factory", Governorate = "الغربية",
        ////            Documents = { "سجل تجاري", "بطاقة ضريبية" }, SubmittedAt = new DateTime(2026, 11, 12, 9, 14, 0) },
        ////    new() { Id = 2, Name = "شركة الفيروز للملابس", Role = "factory", Governorate = "الإسكندرية",
        ////            Documents = { "سجل تجاري", "بطاقة ضريبية" }, SubmittedAt = new DateTime(2026, 11, 12, 8, 2, 0) },
        ////    new() { Id = 3, Name = "ورشة يد مصرية", Role = "workshop", Governorate = "القاهرة",
        ////            Documents = { "بطاقة هوية" }, SubmittedAt = new DateTime(2026, 11, 11, 21, 40, 0) },
        ////    new() { Id = 4, Name = "أحمد سعيد", Role = "driver", Governorate = "الجيزة",
        ////            Documents = { "رخصة قيادة", "رخصة مركبة" }, SubmittedAt = new DateTime(2026, 11, 11, 18, 25, 0) },
        ////    new() { Id = 5, Name = "مصنع الشروق للتريكو", Role = "factory", Governorate = "القليوبية",
        ////            Documents = { "سجل تجاري" }, MissingDocument = "البطاقة الضريبية",
        ////            SubmittedAt = new DateTime(2026, 11, 11, 15, 10, 0) },
        ////    new() { Id = 6, Name = "مشغل الصفا", Role = "workshop", Governorate = "الدقهلية",
        ////            Documents = { "بطاقة هوية" }, SubmittedAt = new DateTime(2026, 11, 11, 11, 47, 0) },
        ////    new() { Id = 7, Name = "كريم فتحي", Role = "driver", Governorate = "الشرقية",
        ////            Documents = { "رخصة قيادة", "رخصة مركبة" }, SubmittedAt = new DateTime(2026, 11, 10, 22, 3, 0) },
        ////}; 

        //#endregion





    }
}
