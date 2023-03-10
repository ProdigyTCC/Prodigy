using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class ProdutoController : Controller
    {
        private readonly Sistema01Context _context;

        public ProdutoController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produto = _context.Produtos.ToList();
            return View(produto);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }
        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.ProdutoId);

            produtoBanco.Nome = produto.Nome;
            produtoBanco.DescProduto = produto.DescProduto;
            produtoBanco.QuantProduto = produto.QuantProduto;
            produtoBanco.Marca = produto.Marca;
            produtoBanco.DataValidade = produto.DataValidade;
            produtoBanco.DataEntrada = produto.DataValidade;
            produtoBanco.Imagem1 = produto.Imagem1;
            produtoBanco.Imagem2 = produto.Imagem2;
            produtoBanco.ValorInicial = produto.ValorInicial;
            produtoBanco.ValorFinal = produto.ValorFinal;

            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        public IActionResult Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }
        [HttpPost]
        public IActionResult Deletar(Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.ProdutoId);

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();
 
            return RedirectToAction(nameof(Index));
        }
    }
}
