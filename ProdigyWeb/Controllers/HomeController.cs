using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    public IActionResult Sobre()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    public IActionResult Contato()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    public IActionResult Perfil()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    public IActionResult Login()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    public IActionResult Cadastro()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    public IActionResult Planos()
    {
        ViewBag.Layout = "ProdigyWeb";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
