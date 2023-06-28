using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SCaixaController : Controller
    {
        private readonly ProdigyWebContext _context;

        public SCaixaController(ProdigyWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;
            
            if (claims.Identity.IsAuthenticated)
            {
                var moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("NovaVenda")]
        public IActionResult NovaVenda()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var moduloBanco = _context.Modulos.FirstOrDefault(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }
    }
}
