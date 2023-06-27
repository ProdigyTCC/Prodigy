using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SHomeController : Controller
    {
        public IActionResult Index(string? msg)
        {
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                ViewBag.color = "#E2F0EF";
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login","Usuario");
        }
    }
}
