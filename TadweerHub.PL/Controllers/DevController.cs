using Microsoft.AspNetCore.Mvc;

namespace TadweerHub.PL.Controllers
{
    // مؤقت للتطوير فقط: بيبدّل الدور عشان تشوف الـ Navbar والشاشات بتاعة كل دور.
    // الاستخدام: /Dev/Role/workshop  أو  factory  أو  driver  أو  admin  أو  guest
    // هيتمسح لما نركّب تسجيل الدخول الحقيقي.
    public class DevController : Controller
    {
        private static readonly string[] Roles = { "guest", "workshop", "factory", "driver", "admin" };

        public IActionResult Role(string id)
        {
            if (!Roles.Contains(id)) id = "guest";
            Response.Cookies.Append("tw-role", id);
            return Redirect("/");
        }
    }
}
