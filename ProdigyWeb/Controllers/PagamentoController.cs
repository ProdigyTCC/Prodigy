using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;
using System.Data.Common;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    public class PagamentoController : Controller
    {
        private string Plano = "";
        private readonly ProdigyWebContext _context;
        public PagamentoController(ProdigyWebContext context)
        {
            _context = context;
        }
        public void AddSessao()
        {
            ViewBag.Id = User.FindFirst("Id")?.Value;
            ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.Layout = "ProdigyWeb";
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                AddSessao();
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }
        
        [HttpPost("AddPlano")]
        public async Task<IActionResult> AddPlano(string? plano) 
        {
            var usuarioId = User.FindFirst("Id")?.Value;

            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);

            try
            {
                if (usuarios == null) 
                {
                    TempData["Erro"] = "Faça o login primeiro!";
                    return RedirectToAction("Login", "Usuario");
                }
                Plano = plano;
                usuarios.Plano = plano;

                if(plano != "Starter")
                {
                    TempData["Plano"] = plano;
                    return RedirectToAction(nameof(Index));
                }
                _context.Usuarios.Update(usuarios);
                _context.SaveChanges();
                return RedirectToAction("Index", "Usuario");
            }
            catch(DbException e)
            {
                TempData["Erro"] = $"Erro ao adicionar pagamento: {e.Message}";
                return RedirectToAction("Planos", "Home");
            }
        }

        [HttpPost("AdicionarCartao")]
        public async Task<IActionResult> AdicionarCartao(string nomeCartao, string numeroCartao, string cpfTitular, string mesCartao, string anoCartao, string cvCartao, string plano)
        {
            var usuarioId = User.FindFirst("Id")?.Value;
                
            var cartao = new Cartao
            {
                NumeroCartao = numeroCartao,
                Codigo = int.Parse(cvCartao),
                NomeTitular = nomeCartao,
                TipoCartao = "Crédito",
                CpfTitular = cpfTitular,
                ValidadeCartao = $"{mesCartao}/{anoCartao}",
                UsuarioId = int.Parse(usuarioId)
            };

            try
            {
                var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);

                if (cartao != null && usuarios != null)
                {
                    usuarios.Plano = plano;

                    _context.Cartoes.Add(cartao);
                    _context.Usuarios.Update(usuarios);
                    _context.SaveChanges();
                    TempData["Sucesso"] = "Cartão cadastrado com sucesso!";
                    return RedirectToAction("Index", "Usuario");
                }
                TempData["Erro"] = "As informações do cartão estão inválidas!";
                return RedirectToAction(nameof(Index));
            }
            catch(DbException e)
            {
                TempData["Erro"] = $"Não foi possivel salvar seu cartão: {e.Message}!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
