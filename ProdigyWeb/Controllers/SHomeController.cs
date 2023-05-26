using Microsoft.AspNetCore.Mvc;

namespace ProdigyWeb.Controllers
{
    public class SHomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Layout = "Dashboard";
            return View();
        }

        public IActionResult Estoque()
        {
            ViewBag.Layout = "Dashboard";
            return View();
        }

        public IActionResult Caixa()
        {
            ViewBag.Layout = "Caixa";
            return View();
        }
    }
}
