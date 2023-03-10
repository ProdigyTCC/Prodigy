using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class FuncionarioController : Controller
    {
        private readonly Sistema01Context _context;

        public FuncionarioController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var funcionario = _context.Funcionarios.ToList();
            return View(funcionario);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }
        public IActionResult Editar(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(funcionario.FuncionarioId);

            funcionarioBanco.Nome = funcionario.Nome;
            funcionarioBanco.Pis = funcionario.Pis;
            funcionarioBanco.Nivel = funcionario.Nivel;
            funcionarioBanco.DataRegistro = funcionario.DataRegistro;
            funcionarioBanco.DataPagamento = funcionario.DataPagamento;
            funcionarioBanco.DataNascimento = funcionario.DataNascimento;
            funcionarioBanco.Imagem = funcionario.Imagem;
            funcionarioBanco.EstadoCivil = funcionario.EstadoCivil;
            funcionarioBanco.Sexo = funcionario.Sexo;
            funcionarioBanco.Cpf = funcionario.Cpf;
            funcionarioBanco.Habilitacao = funcionario.Habilitacao;
            funcionarioBanco.Salario = funcionario.Salario;
            funcionarioBanco.QtFilhos = funcionario.QtFilhos;
            funcionarioBanco.Observacao = funcionario.Observacao;

            _context.Funcionarios.Update(funcionarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }

        public IActionResult Deletar(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }
        [HttpPost]
        public IActionResult Deletar(Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(funcionario.FuncionarioId);

            _context.Funcionarios.Remove(funcionarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
