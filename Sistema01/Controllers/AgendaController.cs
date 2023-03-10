using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    public class AgendaController : Controller
    {
        private readonly Sistema01Context _context;

        public AgendaController(Sistema01Context context)
        {
            var agendas = _context.Agendas.ToList();
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Agendas.Add(agenda);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }
        public IActionResult Editar(int id)
        {
            var agenda = _context.Agendas.Find(id);

            if (agenda == null)
                return RedirectToAction(nameof(Index));

            return View(agenda);
        }

        [HttpPost]
        public IActionResult Editar(Agenda agenda)
        {
            var agendaBanco = _context.Agendas.Find(agenda.AgendaId);

            agendaBanco.Titulo = agenda.Titulo;
            agendaBanco.Data = agenda.Data;
            agendaBanco.Descricao = agenda.Descricao;

            _context.Agendas.Update(agenda);
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
            var agenda = _context.Agendas.Find(id);

            if (agenda == null)
                return RedirectToAction(nameof(Index));

            return View(agenda);
        }
        [HttpPost]
        public IActionResult Deletar(Agenda agenda)
        {
            var agendaBanco = _context.Agendas.Find(agenda.AgendaId);

            _context.Agendas.Remove(agendaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
