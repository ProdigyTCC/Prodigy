using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SFornecedorController : Controller
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

        [HttpGet("AddFornecedor")]
        public IActionResult AddFornecedor()
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
