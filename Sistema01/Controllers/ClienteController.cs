using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class ClienteController : Controller
    {
        private readonly Sistema01Context _context;

        public ClienteController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        public IActionResult Editar(int id)
        {
            var cliente= _context.Clientes.Find(id);

            if (cliente== null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            var clienteBanco = _context.Clientes.Find(cliente.ClienteId);

            clienteBanco.Nome = cliente.Nome;
            clienteBanco.Cpf = cliente.Cpf;
            clienteBanco.DataNacimento = cliente.DataNacimento;
            clienteBanco.DataRegistro = cliente.DataRegistro;
            
            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        public IActionResult Deletar(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }
        [HttpPost]
        public IActionResult Deletar(Cliente cliente)
        {
            var clienteBanco = _context.Clientes.Find(cliente.ClienteId);

            _context.Clientes.Remove(clienteBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
