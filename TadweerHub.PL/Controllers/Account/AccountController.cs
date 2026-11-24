using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels.Account;

namespace TadweerHub.PL.Controllers.Account
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var email = model.Email.ToLowerInvariant();
            var role = email.Contains("factory") ? "factory"
                : email.Contains("driver") ? "driver"
                : email.Contains("admin") ? "admin"
                : "workshop";

            Response.Cookies.Append(MockSession.CookieName, role);
            var home = MockSession.HomeRoute(role);
            return RedirectToAction(home.Action, home.Controller);
        }

        [HttpGet]
        public IActionResult Register(string? role)
        {
            var selectedRole = role is "factory" or "workshop" or "driver" ? role : "workshop";
            return View(new RegisterVM { Role = selectedRole });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Response.Cookies.Append(MockSession.CookieName, model.Role);
            var home = MockSession.HomeRoute(model.Role);
            return RedirectToAction(home.Action, home.Controller);
        }
    }
}
