using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdigyWeb.Models;
using ProdigyWeb.Data;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class ContaBancariaController : Controller
    {
        private readonly ProdigyWebContext _context;

        public ContaBancariaController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contaBancarias = _context.ContaBancarias.ToList();
            return View(contaBancarias);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContaBancaria contaBancaria)
        {
            if (ModelState.IsValid)
            {
                _context.ContaBancarias.Add(contaBancaria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contaBancaria);
        }
        public IActionResult Editar(int id)
        {
            var contaBancaria = _context.ContaBancarias.Find(id);

            if (contaBancaria == null)
                return RedirectToAction(nameof(Index));

            return View(contaBancaria);
        }

        [HttpPost]
        public IActionResult Editar(ContaBancaria contaBancaria)
        {
            var contaBancariaBanco = _context.ContaBancarias.Find(contaBancaria.ContaBancariaId);

            contaBancariaBanco.NomeTitular = contaBancaria.NomeTitular;
            contaBancariaBanco.CpfTitular = contaBancaria.CpfTitular;
            contaBancariaBanco.CnpjTitular = contaBancaria.CnpjTitular;
            contaBancariaBanco.Conta = contaBancaria.Conta;
            contaBancariaBanco.Agencia = contaBancaria.Agencia;
            contaBancariaBanco.TipoConta = contaBancaria.TipoConta;
            contaBancariaBanco.CobrancaAuto = contaBancaria.CobrancaAuto;

            _context.ContaBancarias.Update(contaBancariaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var contaBancaria = _context.ContaBancarias.Find(id);

            if (contaBancaria == null)
                return RedirectToAction(nameof(Index));

            return View(contaBancaria);
        }

        public IActionResult Deletar(int id)
        {
            var contaBancaria = _context.ContaBancarias.Find(id);

            if (contaBancaria == null)
                return RedirectToAction(nameof(Index));

            return View(contaBancaria);
        }
        [HttpPost]
        public IActionResult Deletar(ContaBancaria contaBancaria)
        {
            var contaBancariaBanco = _context.ContaBancarias.Find(contaBancaria.ContaBancariaId);

            _context.ContaBancarias.Remove(contaBancariaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}