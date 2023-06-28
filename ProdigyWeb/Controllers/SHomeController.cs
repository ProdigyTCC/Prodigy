using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SHomeController : Controller
    {
        private readonly ProdigyWebContext _context;

        public SHomeController(ProdigyWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? msg)
        {
            var moduloBanco = new Modulo();
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                if (moduloBanco != null)
                {
                    moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }

                var pedidos = _context.SPedidos.Where(x => x.UsuarioId.ToString() == usuarioId).ToList();
                var produtos = _context.SProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToList();

                TempData["Msg"] = msg;
                ViewBag.Pedidos = "";
                ViewBag.Produtos = "";
                if (pedidos != null) ViewBag.Pedidos = pedidos;
                if (pedidos != null) ViewBag.Produtos = produtos;

                return View();
            }
            return RedirectToAction("Login","Usuario");
        }
    }
}
