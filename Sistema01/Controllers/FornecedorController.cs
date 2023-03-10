using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class FornecedorController : Controller
    {
        private readonly Sistema01Context _context;

        public FornecedorController(Sistema01Context context)
        {
            _context = context;
        }   

        public ActionResult Index()
        {
            var fornecedores = _context.Fornecedores.ToList();
            return View(fornecedores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Fornecedores.Add(fornecedor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }
        public IActionResult Editar(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);

            if (fornecedor == null)
                return RedirectToAction(nameof(Index));

            return View(fornecedor);
        }

        [HttpPost]
        public IActionResult Editar(Fornecedor fornecedor)
        {
            var fornecedorBanco = _context.Fornecedores.Find(fornecedor.FornecedorId);

            fornecedorBanco.NomeRazao = fornecedor.NomeRazao;
            fornecedorBanco.Cnpj = fornecedor.Cnpj;
            fornecedorBanco.CpfRepresentante = fornecedor.CpfRepresentante;
            fornecedorBanco.RgMunicipal = fornecedor.RgMunicipal;
            fornecedorBanco.RgEstadual = fornecedor.RgEstadual;
            fornecedorBanco.DataFundacao = fornecedor.DataFundacao;
            fornecedorBanco.NomeRepresentante = fornecedor.NomeRepresentante;;
            
            _context.Fornecedores.Update(fornecedorBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);

            if (fornecedor == null)
                return RedirectToAction(nameof(Index));

            return View(fornecedor);
        }

        public IActionResult Deletar(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);

            if (fornecedor == null)
                return RedirectToAction(nameof(Index));

            return View(fornecedor);
        }
        [HttpPost]
        public IActionResult Deletar(Fornecedor fornecedor)
        {
            var fornecedorBanco = _context.Fornecedores.Find(fornecedor.FornecedorId);

            _context.Fornecedores.Remove(fornecedorBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
