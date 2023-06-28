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

        public IActionResult Index()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var moduloBanco = _context.Modulos.FirstOrDefault(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                ViewBag.Layout = "Dashboard";
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoPedido" && moduloBanco.NomeSistema != null)
                        ViewBag.Modulo = "AcessoPedido";
                }

                var pedidos = _context.SPedidos.Where(x => x.UsuarioId.ToString() == usuarioId).ToList();
                var produtos = _context.SProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToList();
                
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
