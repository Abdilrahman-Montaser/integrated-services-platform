using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TadweerHub.PL.Mock;
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
        public string Role {  get; set; }
        public string City {  get; set; }
        public string Status {  get; set; }

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
            var pendingAccounts = new List<PendingAccount>
            {
                new PendingAccount{Id=1,Name="مصنع النيل للغزل ",Role="Factory",City="المحلة الكبري",Status="Pending"},
                new PendingAccount{Id=2,Name="محمود السيد ",Role="Driver",City="المنوفية",Status="Pending"},

            };
            return View(pendingAccounts);
        }


    }
}
