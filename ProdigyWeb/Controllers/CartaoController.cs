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
    public class CartaoController : Controller
    {
        private readonly ProdigyWebContext _context;

        public CartaoController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cartoes = _context.Cartoes.ToList();
            return View(cartoes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                _context.Cartoes.Add(cartao);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cartao);
        }
        public IActionResult Editar(int id)
        {
            var cartao = _context.Cartoes.Find(id);

            if (cartao == null)
                return RedirectToAction(nameof(Index));

            return View(cartao);
        }

        [HttpPost]
        public IActionResult Editar(Cartao cartao)
        {
            var cartaoBanco = _context.Cartoes.Find(cartao.CartaoId);

            cartaoBanco.NumeroCartao = cartao.NumeroCartao;
            cartaoBanco.NomeTitular = cartao.NomeTitular;
            cartaoBanco.CnpjTitular = cartao.CnpjTitular;
            cartaoBanco.CpfTitular = cartao.CpfTitular;
            cartaoBanco.ValidadeCartao = cartao.ValidadeCartao;

            _context.Cartoes.Update(cartaoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var cartao = _context.Cartoes.Find(id);

            if (cartao == null)
                return RedirectToAction(nameof(Index));

            return View(cartao);
        }

        public IActionResult Deletar(int id)
        {
            var cartaoBanco = _context.Cartoes.Find(id);

            if (cartaoBanco == null)
                return RedirectToAction(nameof(Index));

            return View(cartaoBanco);
        }
        [HttpPost]
        public IActionResult Deletar(Cartao cartao)
        {
            var cartaoBanco = _context.Cartoes.Find(cartao.CartaoId);

            _context.Cartoes.Remove(cartaoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}