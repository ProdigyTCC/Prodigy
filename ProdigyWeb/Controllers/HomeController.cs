using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers;

public class HomeController : Controller
{
    public void AddSessao()
    {
        ViewBag.Id = User.FindFirst("Id")?.Value;
        ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
        ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
    }
    public IActionResult Index()
    {
        ViewBag.Layout = "ProdigyWeb";

        AddSessao();
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

    public IActionResult Planos()
    {
        ViewBag.Layout = "ProdigyWeb";

        AddSessao();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
