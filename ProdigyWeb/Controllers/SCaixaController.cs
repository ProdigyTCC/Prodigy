using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SCaixaController : Controller
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

        [HttpGet("NovaVenda")]
        public IActionResult NovaVenda()
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
