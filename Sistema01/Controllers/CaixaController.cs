using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class CaixaController : Controller
    {
        private readonly Sistema01Context _context;

        public CaixaController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var caixa = _context.Caixas.ToList();
            return View(caixa);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Caixa caixa)
        {
            if (ModelState.IsValid)
            {
                _context.Caixas.Add(caixa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(caixa);
        }

        public IActionResult Editar(int id)
        {
            var caixa = _context.Caixas.Find(id);

            if (caixa == null)
                return RedirectToAction(nameof(Index));

            return View(caixa);
        }

        [HttpPost]
        public IActionResult Editar(Caixa caixa)
        {
            var caixaBanco = _context.Caixas.Find(caixa.CaixaId);

            caixaBanco.ValorAbertura = caixa.ValorAbertura;
            caixaBanco.ValorFechamento = caixa.ValorFechamento;

            _context.Caixas.Update(caixa);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var caixa = _context.Caixas.Find(id);

            if (caixa == null)
                return RedirectToAction(nameof(Index));

            return View(caixa);
        }

        public IActionResult Deletar(int id)
        {
            var caixa = _context.Caixas.Find(id);

            if (caixa == null)
                return RedirectToAction(nameof(Index));

            return View(caixa);
        }
        [HttpPost]
        public IActionResult Deletar(Caixa caixa)
        {
            var caixaBanco = _context.Caixas.Find(caixa.CaixaId);

            _context.Caixas.Remove(caixaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
