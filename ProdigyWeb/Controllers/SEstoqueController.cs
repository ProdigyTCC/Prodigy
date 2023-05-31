using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;
using System.Data.Common;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    public class SEstoqueController : Controller
    {
        private readonly ProdigyWebContext _context;
        public SEstoqueController(ProdigyWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                var produtos = await _context.SProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToListAsync();

                if (produtos != null) return View(produtos);
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddProduto")]
        public async Task<IActionResult> AddProduto()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var categProduto = await _context.SCategoriaProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToListAsync();

                ViewBag.CategProduto = categProduto;
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddProdutoBanco")]
        public async Task<IActionResult> AddProdutoBanco(SProduto produto)
        {
            var produtoBanco = await _context.SProdutos.FindAsync(produto.Nome);
            var usuarioId = User.FindFirst("Id")?.Value;

            try
            {
                if(produtoBanco != null)
                {
                    produto.UsuarioId = int.Parse(usuarioId);
                    _context.SProdutos.Add(produto);
                    _context.SaveChanges();
                    TempData["Sucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Erro"] = "Este produta já existe em seu estoque!\nVocê podê atualizar ele em edições de produto.";
                return RedirectToAction(nameof(AddProduto));
            }
            catch(DbException e)
            {
                TempData["Erro"] = $"Erro cadastrar o produto {e.Message}";
                ViewBag.Produto = produto;
                return RedirectToAction(nameof(AddProduto));
            }
        }

        [HttpPost("AddCategoriaProduto")]
        public async Task<IActionResult> AddCategoriaProduto(string nome, string descCategoria)
        {
            var categProdutosBanco = await _context.SCategoriaProdutos.Where(x => x.Nome.Equals(nome)).FirstOrDefaultAsync();
            var usuarioId = User.FindFirst("Id")?.Value;

            var categProduto = new SCategoriaProduto()
            {
                Nome = nome,
                DescCategoria = descCategoria,
                UsuarioId = int.Parse(usuarioId)
            };

            try
            {
                if(categProdutosBanco == null)
                {
                    _context.SCategoriaProdutos.Add(categProduto);
                    _context.SaveChanges();
                    TempData["Sucesso"] = "Categoria cadastrada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Erro"] = "Esta categoria já existe!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbException e)
            {
                TempData["Erro"] = $"Erro ao cadastrar no banco {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
