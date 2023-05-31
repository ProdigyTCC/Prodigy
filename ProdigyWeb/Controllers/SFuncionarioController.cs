using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    public class SFuncionarioController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }
    }
}
