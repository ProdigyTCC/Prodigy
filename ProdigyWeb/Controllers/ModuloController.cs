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
    public class ModuloController : Controller
    {
        private readonly ProdigyWebContext _context;

        public ModuloController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var modulos = _context.Modulos.ToList();
            return View(modulos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Modulos.Add(modulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(modulo);
        }
        
        public IActionResult Editar(int id)
        {
            var modulo = _context.Modulos.Find(id);

            if (modulo == null)
                return RedirectToAction(nameof(Index));

            return View(modulo);
        }
        
        [HttpPost]
        public IActionResult Editar(Modulo modulo)
        {
            var moduloBanco = _context.Modulos.Find(modulo.ModuloId);

            moduloBanco.NomeSistema = modulo.NomeSistema;
            moduloBanco.Plano = modulo.Plano;

            _context.Modulos.Update(moduloBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var modulo = _context.Modulos.Find(id);

            if (modulo == null)
                return RedirectToAction(nameof(Index));

            return View(modulo);
        }

        public IActionResult Deletar(int id)
        {
            var modulo = _context.Modulos.Find(id);

            if (modulo == null)
                return RedirectToAction(nameof(Index));

            return View(modulo);
        }

        [HttpPost]
        public IActionResult Deletar(Modulo modulo)
        {
            var moduloBanco = _context.Modulos.Find(modulo.ModuloId);

            _context.Modulos.Remove(moduloBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}