using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class ModuloController : Controller
    {
        private readonly ProdigyWebContext _context;

        public ModuloController(ProdigyWebContext context)
        {
            _context = context;
        }
        public void AddSessao()
        {
            ViewBag.Id = User.FindFirst("Id")?.Value;
            ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.Nivel = User.FindFirst(ClaimTypes.Role)?.Value;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var moduloBanco = new Modulo();
            var usuarioId = User.FindFirst("Id")?.Value;
            ClaimsPrincipal claims = HttpContext.User;
            ViewBag.Layout = "ProdigyWeb";

            if (claims.Identity.IsAuthenticated)
            {
                moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                AddSessao();
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoFuncionario")
                        ViewBag.Modulo = "AcessoFuncionario";
                }
                else ViewBag.Modulo = "";
                return View();
            }

            if (moduloBanco != null)
            {
                if (moduloBanco.NomeSistema == "AcessoFuncionario")
                    ViewBag.Modulo = "AcessoFuncionario";
            }
            else ViewBag.Modulo = "";
            return View();
        }

        [HttpPost("AddModulo")]
        public async Task<IActionResult> AddModulo(Modulo modulo)
        {
            var usuarioId = User.FindFirst("Id")?.Value;

            try
            {
                if(ModelState.IsValid)
                {
                    var moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                    //var cartao = await _context.Cartoes.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));

                    if(moduloBanco != null)
                    {
                        TempData["Erro"] = "Você já tem este modulo ativo";
                        return RedirectToAction(nameof(Index));
                    }

                    //if (moduloBanco == null)
                    //{
                    //    return RedirectToAction("Index", "Pagamento");
                    //}

                    modulo.UsuarioId = int.Parse(usuarioId);

                    _context.Modulos.Add(modulo);
                    _context.SaveChanges();

                    TempData["Sucesso"] = "Modulo adicionado!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Erro"] = "Algo inesperado aconteceu!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Erro"] = "Algo inesperado aconteceu!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}