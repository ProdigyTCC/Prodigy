using Microsoft.AspNetCore.Mvc;

namespace ProdigyWeb.Controllers
{
    public class SHomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Layout = "Sistema01";
            return View();
        }
    }
}
