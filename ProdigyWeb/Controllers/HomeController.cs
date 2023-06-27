using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ProdigyWeb.Controllers
{
    public class HomeController : Controller
    {
        public void AddSessao()
        {
            ViewBag.Id = User.FindFirst("Id")?.Value;
            ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.Nivel = User.FindFirst(ClaimTypes.Role)?.Value;
        }
        public IActionResult Index(string? msg)
        {
            ViewBag.Layout = "ProdigyWeb";
            AddSessao();
            TempData["Msg"] = msg;
            return View();
        }

        public IActionResult Sobre()
        {
            ViewBag.Layout = "ProdigyWeb";

            AddSessao();
            return View();
        }

        public IActionResult Contato()
        {
            ViewBag.Layout = "ProdigyWeb";

            AddSessao();
            return View();
        }

        public IActionResult Planos(string? msg)
        {
            ViewBag.Layout = "ProdigyWeb";
            AddSessao();
            TempData["Msg"] = msg;
            return View();
        }
    }
}