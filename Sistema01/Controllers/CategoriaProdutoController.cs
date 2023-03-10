using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    public class CategoriaProdutoController : Controller
    {
        private readonly Sistema01Context _context;

        public CategoriaProdutoController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categoriaProdutos = _context.CategoriaProdutos.ToList();
            return View(categoriaProdutos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                _context.CategoriaProdutos.Add(categoriaProduto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProduto);
        }
        public IActionResult Editar(int id)
        {
            var categoriaProduto = _context.CategoriaProdutos.Find(id);

            if (categoriaProduto == null)
                return RedirectToAction(nameof(Index));

            return View(categoriaProduto);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaProduto categoriaProduto)
        {
            var categoriaProdutoBanco = _context.Clientes.Find(categoriaProduto.CategoriaProdutoId);

            categoriaProdutoBanco.Nome = categoriaProduto.Nome;

            _context.CategoriaProdutos.Update(categoriaProduto);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var categoriaProduto = _context.CategoriaProdutos.Find(id);

            if (categoriaProduto == null)
                return RedirectToAction(nameof(Index));

            return View(categoriaProduto);
        }

        public IActionResult Deletar(int id)
        {
            var categoriaProduto = _context.CategoriaProdutos.Find(id);

            if (categoriaProduto == null)
                return RedirectToAction(nameof(Index));

            return View(categoriaProduto);
        }
        [HttpPost]
        public IActionResult Deletar(CategoriaProduto categoriaProduto)
        {
            var categoriaProdutoBanco = _context.CategoriaProdutos.Find(categoriaProduto.CategoriaProdutoId);

            _context.CategoriaProdutos.Remove(categoriaProdutoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
