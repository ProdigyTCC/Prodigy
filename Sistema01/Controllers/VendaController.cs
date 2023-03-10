using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class VendaController : Controller
    {
        private readonly Sistema01Context _context;

        public VendaController(Sistema01Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var venda = _context.Vendas.ToList();
            return View(venda);
        }

        [HttpPost]
        public IActionResult Criar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Vendas.Add(venda);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }
        public IActionResult Editar(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
                return RedirectToAction(nameof(Index));

            return View(venda);
        }

        [HttpPost]
        public IActionResult Editar(Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(venda.VendaId);

            vendaBanco.Valor = venda.Valor;
            vendaBanco.DataVenda = venda.DataVenda;
            vendaBanco.FormaPagamento = venda.FormaPagamento;
            vendaBanco.Produto = venda.Produto;

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
                return RedirectToAction(nameof(Index));

            return View(venda);
        }

        public IActionResult Deletar(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
                return RedirectToAction(nameof(Index));

            return View(venda);
        }
        [HttpPost]
        public IActionResult Deletar(Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(venda.VendaId);

            _context.Vendas.Remove(vendaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
