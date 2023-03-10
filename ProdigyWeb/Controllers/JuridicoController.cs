using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class JuridicoController : Controller
    {
        private readonly ProdigyWebContext _context;

        public JuridicoController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var juridicos = _context.Juridicos.ToList();
            return View(juridicos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Juridico juridico)
        {
            if (ModelState.IsValid)
            {
                _context.Juridicos.Add(juridico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(juridico);
        }

        public IActionResult Editar(int id)
        {
            var juridico = _context.Juridicos.Find(id);

            if (juridico == null)
                return RedirectToAction(nameof(Index));

            return View(juridico);
        }
        
        [HttpPost]
        public IActionResult Editar(Juridico juridico)
        {
            var juridicoBanco = _context.Juridicos.Find(juridico.JuridicoId);

            juridicoBanco.NomeRazao = juridico.NomeRazao;
            juridicoBanco.Cnpj = juridico.Cnpj;
            juridicoBanco.RgEstadual = juridico.RgEstadual;
            juridicoBanco.RgMunicipal = juridico.RgMunicipal;
            juridicoBanco.Natureza = juridico.Natureza;
            juridicoBanco.DataFundacao = juridico.DataFundacao;
            
            _context.Juridicos.Update(juridicoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var juridico = _context.Juridicos.Find(id);

            if (juridico == null)
                return RedirectToAction(nameof(Index));

            return View(juridico);
        }

        public IActionResult Deletar(int id)
        {
            var juridico = _context.Juridicos.Find(id);

            if (juridico == null)
                return RedirectToAction(nameof(Index));

            return View(juridico);
        }
        [HttpPost]
        public IActionResult Deletar(Juridico juridico)
        {
            var juridicoBanco = _context.Juridicos.Find(juridico.JuridicoId);

            _context.Juridicos.Remove(juridicoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}