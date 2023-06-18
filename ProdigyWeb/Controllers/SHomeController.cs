using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    public class SHomeController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                ViewBag.color = "#E2F0EF";
                return View();
            }
            return RedirectToAction("Login","Usuario");
        }
    }
}
