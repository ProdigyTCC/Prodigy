using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sistema01.Models;
using Sistema01.Data;

namespace Sistema01.Controllers;

public class Home2Controller : Controller
{
    public IActionResult Index()
    {
        ViewBag.Layout = "Sistema01";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
