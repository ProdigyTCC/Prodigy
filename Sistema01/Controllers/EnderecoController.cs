using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class EnderecoController : Controller
    {
        private readonly Sistema01Context _context;
        public EnderecoController(Sistema01Context context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var enderecos = _context.Enderecos.ToList();
            return View(enderecos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }
      
        public IActionResult Editar(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return RedirectToAction(nameof(Index));

            return View(endereco);
        }

        [HttpPost]
        public IActionResult Editar(Endereco endereco)
        {
            var enderecoBanco = _context.Enderecos.Find(endereco.EnderecoId);

            enderecoBanco.Rua = endereco.Rua;
            enderecoBanco.Numero = endereco.Numero;
            enderecoBanco.Complemento = endereco.Complemento;
            enderecoBanco.Bairro = endereco.Bairro;
            enderecoBanco.Cep = endereco.Cep;
            enderecoBanco.Estado = endereco.Estado;
            enderecoBanco.Cidade = endereco.Cidade;
            enderecoBanco.Pais = endereco.Pais;
            
            _context.Enderecos.Update(enderecoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return RedirectToAction(nameof(Index));

            return View(endereco);
        }

        public IActionResult Deletar(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
                return RedirectToAction(nameof(Index));

            return View(endereco);
        }
        [HttpPost]
        public IActionResult Deletar(Endereco endereco)
        {
            var enderecoBanco = _context.Enderecos.Find(endereco.EnderecoId);

            _context.Enderecos.Remove(enderecoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
