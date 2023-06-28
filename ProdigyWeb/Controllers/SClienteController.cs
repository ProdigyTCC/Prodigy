using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;
using System.Data.Common;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SClienteController : Controller
    {
        private readonly ProdigyWebContext _context;

        public SClienteController(ProdigyWebContext context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? msg, string? nome = "")
        {
            var moduloBanco = new Modulo();
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var clientes = _context.SClientes.Where(x => x.UsuarioId == int.Parse(usuarioId));
                if (moduloBanco != null)
                {
                    moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }
                if (nome != "")
                {
                    clientes = clientes.Where(x => x.SClienteId.ToString() == nome || x.Nome.Contains(nome));
                    ViewBag.Layout = "Dashboard";
                    if(clientes != null) return View(clientes);
                }

                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                if(clientes != null) return View(clientes);

                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddCliente")]
        public async Task<IActionResult> AddClienteAsync(string? msg)
        {
            var moduloBanco = new Modulo();
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                if (moduloBanco != null)
                {
                    moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }
                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddClienteBanco")]
        public async Task<IActionResult> AddClienteBanco(SCliente cliente)
        {
            string msg;
            var usuarioId = User.FindFirst("Id")?.Value;

            var clienteBanco = await _context.SClientes.FirstOrDefaultAsync(x => x.Cpf.Equals(cliente.Cpf) &&
                x.UsuarioId.ToString().Equals(usuarioId));
            try
            {
                if(clienteBanco == null)
                {
                    cliente.UsuarioId = int.Parse(usuarioId);
                    cliente.DataRegistro = DateTime.UtcNow.ToString("dd/MM/yyyy");

                    _context.SClientes.Add(cliente);
                    _context.SaveChanges();

                    msg = "Cliente cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }
                
                msg = "Este cliente já existe em seu sistema!";
                return RedirectToAction(nameof(AddClienteAsync), new {msg});
            }
            catch(DbException)
            {
                msg = "Erro ao cadastrar o cliente";
                return RedirectToAction(nameof(AddClienteAsync), new {msg});
            }
        }
    
        [HttpGet("Editar")]
        public async Task<IActionResult> Editar(string? msg, int? id)
        {
            var clientes = await _context.SClientes.FirstOrDefaultAsync(x => x.SClienteId.Equals(id));

            var moduloBanco = new Modulo();
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                if (moduloBanco != null)
                {
                    moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }
                if (clientes != null)
                {
                    if (moduloBanco != null)
                    {
                        moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                        if (moduloBanco.NomeSistema == "AcessoPedido")
                            ViewBag.Modulo = "AcessoPedido";
                    }
                    ViewBag.Layout = "Dashboard";
                    TempData["Msg"] = msg;
                    return View(clientes);
                }
                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }
    
        [HttpPost("EditarCliente")]
        public async Task<IActionResult> EditarCliente(SCliente cliente)
        {
            string msg;
            var usuarioId = User.FindFirst("Id")?.Value;

            var clienteBanco = await _context.SClientes.FirstOrDefaultAsync(x => x.UsuarioId.ToString().Equals(usuarioId));

            try
            {
                if (clienteBanco != null)
                {

                    if(!string.IsNullOrEmpty(cliente.Nome)) clienteBanco.Nome = cliente.Nome;
                    if(!string.IsNullOrEmpty(cliente.Cpf)) clienteBanco.Cpf = cliente.Cpf;
                    if(!string.IsNullOrEmpty(cliente.Sexo)) clienteBanco.Sexo = cliente.Sexo;
                    if(!string.IsNullOrEmpty(cliente.Email)) clienteBanco.Email = cliente.Email;
                    if(!string.IsNullOrEmpty(cliente.DataNacimento)) clienteBanco.DataNacimento = cliente.DataNacimento;
                    if(!string.IsNullOrEmpty(cliente.Telefone)) clienteBanco.Telefone = cliente.Telefone;

                    if (!string.IsNullOrEmpty(cliente.Rua)) clienteBanco.Rua = cliente.Rua;
                    if (!string.IsNullOrEmpty(cliente.Numero)) clienteBanco.Numero = cliente.Numero;
                    if (!string.IsNullOrEmpty(cliente.Bairro)) clienteBanco.Bairro = cliente.Bairro;
                    if (!string.IsNullOrEmpty(cliente.Complemento)) clienteBanco.Complemento = cliente.Complemento;
                    if (!string.IsNullOrEmpty(cliente.Cep)) clienteBanco.Cep = cliente.Cep;
                    if (!string.IsNullOrEmpty(cliente.Cidade)) clienteBanco.Cidade = cliente.Cidade;
                    if (!string.IsNullOrEmpty(cliente.Estado)) clienteBanco.Estado = cliente.Estado;
                    if (!string.IsNullOrEmpty(cliente.Pais)) clienteBanco.Pais = cliente.Pais;

                    _context.SClientes.Update(clienteBanco);
                    _context.SaveChanges();

                    msg = "Cliente atualizado com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }
                msg = "Erro ao atualizar os dados do cliente!\nTente novamente.";
                return RedirectToAction(nameof(Editar), new {msg});
            }
            catch (DbException)
            {
                msg = "Erro cadastrar o cliente";
                return RedirectToAction(nameof(Editar), new {msg});
            }
        }
    }
}
