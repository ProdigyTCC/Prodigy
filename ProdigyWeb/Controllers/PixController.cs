using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class PixController : Controller
    {
        private readonly ProdigyWebContext _context;

        public PixController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pix = _context.Pix.ToList();
            return View(pix);
        }

        [HttpPost]
        public IActionResult Criar(Pix pix)
        {
            if (ModelState.IsValid)
            {
                _context.Pix.Add(pix);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pix);
        }

        public IActionResult Editar(int id)
        {
            var pix = _context.Pix.Find(id);

            if (pix == null)
                return RedirectToAction(nameof(Index));

            return View(pix);
        }
        
        [HttpPost]
        public IActionResult Editar(Pix pix)
        {
            var pixBanco = _context.Pix.Find(pix.PixId);

            pixBanco.Comprovante = pix.Comprovante;
            pixBanco.QrCodeEstatico = pix.QrCodeEstatico;
            pixBanco.Valor = pix.Valor;

            _context.Pix.Update(pixBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var pix = _context.Pix.Find(id);

            if (pix == null)
                return RedirectToAction(nameof(Index));

            return View(pix);
        }

        public IActionResult Deletar(int id)
        {
            var pix = _context.Pix.Find(id);

            if (pix == null)
                return RedirectToAction(nameof(Index));

            return View(pix);
        }

        [HttpPost]
        public IActionResult Deletar(Pix pix)
        {
            var pixBanco = _context.Pix.Find(pix.PixId);

            _context.Pix.Remove(pixBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}