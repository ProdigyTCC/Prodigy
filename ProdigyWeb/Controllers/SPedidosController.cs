using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public class SPedidosController : Controller
    {
        private readonly ProdigyWebContext _context;

        public SPedidosController(ProdigyWebContext context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index(string? msg, string? pedidoBusca = "")
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                var pedidos = _context.SPedidos.Where(x => x.UsuarioId.Equals(int.Parse(usuarioId))).ToList();
                if (pedidoBusca != "")
                {
                    pedidos = _context.SPedidos.Where(x => x.SPedidoId.ToString().Contains(pedidoBusca) && 
                        x.UsuarioId.ToString().Equals(usuarioId)).ToList();
                        
                    if (pedidos != null) return View(pedidos);
                }
                TempData["Msg"] = msg;
                return View(pedidos);
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddPedido")]
        public IActionResult AddPedido(string? msg, string? produtoPedido = "")
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                var fornecedores = _context.SFornecedores.Where(x => x.SFornecedorId.ToString().Equals(usuarioId)).ToList();

                if (fornecedores != null) ViewBag.Fornecedor = fornecedores;
                else ViewBag.Fornecedor = "";

                var produtos = _context.SProdutos.Where(x => x.UsuarioId.Equals(int.Parse(usuarioId))).ToList();
                if (produtoPedido != "")
                {
                    produtos = _context.SProdutos.Where(x => x.Nome.Contains(produtoPedido) ||
                        x.SProdutoId.ToString().Contains(produtoPedido) && x.UsuarioId.Equals(int.Parse(usuarioId))).ToList();
                    if (produtos != null) return View(produtos);
                    else View();
                }
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("NovoPedido")]
        public IActionResult NovoPedido(SPedido pedido)
        {
            string msg;
            
            var usuarioId = User.FindFirst("Id")?.Value;
            try
            {
                if(ModelState.IsValid)
                {
                    pedido.UsuarioId = int.Parse(usuarioId);
                    pedido.DataPedido = DateTime.UtcNow.ToString("dd/MM/yyyy");
                    pedido.Status = "Pendente";

                    _context.SPedidos.Add(pedido);
                    _context.SaveChanges();
                    msg = "Pedido cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }

                msg = "Erro cadastrar o pedido!";
                return RedirectToAction(nameof(Index), new {msg});
            }
            catch(DbException)
            {
                msg = "Erro cadastrar o pedido!";
                return RedirectToAction(nameof(AddPedido), new {msg});
            }
        }
    }
}