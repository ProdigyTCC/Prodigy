﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("AddFuncionario")]
        public IActionResult AddFuncionario()
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
