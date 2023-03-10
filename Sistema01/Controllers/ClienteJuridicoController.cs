using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class ClienteJuridicoController : Controller
    {
        private readonly Sistema01Context _context;

        public ClienteJuridicoController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clienteJuridicos = _context.ClienteJuridicos.ToList();
            return View(clienteJuridicos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ClienteJuridico clienteJuridico)
        {
            if(ModelState.IsValid)
            {
                _context.ClienteJuridicos.Add(clienteJuridico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteJuridico);
        }
        public IActionResult Editar(int id)
        {
            var clienteJuridico = _context.ClienteJuridicos.Find(id);

            if (clienteJuridico== null)
                return RedirectToAction(nameof(Index));

            return View(clienteJuridico);
        }

        [HttpPost]
        public IActionResult Editar(ClienteJuridico clienteJuridico)
        {
            var clienteJuridicoBanco = _context.ClienteJuridicos.Find(clienteJuridico.ClienteJuridicoId);

            clienteJuridicoBanco.NomeRazao = clienteJuridico.NomeRazao;
            clienteJuridicoBanco.Cnpj = clienteJuridico.Cnpj;
            clienteJuridicoBanco.RgEstadual = clienteJuridico.RgEstadual;
            clienteJuridicoBanco.RgMunicipal = clienteJuridico.RgMunicipal;
            clienteJuridicoBanco.Natureza = clienteJuridico.Natureza;
            clienteJuridicoBanco.DataFundacao = clienteJuridico.DataFundacao;
            clienteJuridicoBanco.DataResgistro = clienteJuridico.DataResgistro;

            _context.ClienteJuridicos.Update(clienteJuridico);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var clienteJuridico = _context.ClienteJuridicos.Find(id);

            if (clienteJuridico == null)
                return RedirectToAction(nameof(Index));

            return View(clienteJuridico);
        }

        public IActionResult Deletar(int id)
        {
            var clienteJuridico = _context.ClienteJuridicos.Find(id);

            if (clienteJuridico == null)
                return RedirectToAction(nameof(Index));

            return View(clienteJuridico);
        }
        [HttpPost]
        public IActionResult Deletar(ClienteJuridico clienteJuridico)
        {
            var clienteJuridicoBanco = _context.ClienteJuridicos.Find(clienteJuridico.ClienteJuridicoId);

            _context.ClienteJuridicos.Remove(clienteJuridicoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
