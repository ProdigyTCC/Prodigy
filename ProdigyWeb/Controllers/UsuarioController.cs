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
    public class UsuarioController : Controller
    {
        private readonly ProdigyWebContext _context;

        public UsuarioController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        public IActionResult Login(Usuario usuario)
        {
            var usuarios = _context.Usuarios.Find(usuario);
            try{
                if(ModelState.IsValid)
                    return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine($"[ERRO] - Excessão: {e}");
                return View();
            } 
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                return RedirectToAction(nameof(Index));

            return View(usuario);
        }
        
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            var usuarioBanco = _context.Usuarios.Find(usuario.UsuarioId);

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Imagem = usuario.Imagem;
            usuarioBanco.DataNascimento = usuario.DataNascimento;
            usuarioBanco.DataRegistro = usuario.DataRegistro;
            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.Status = usuario.Status;
            usuarioBanco.Sexo = usuario.Sexo;
            usuarioBanco.Raca = usuario.Raca;
            usuarioBanco.Nacionalidade = usuario.Nacionalidade;
            usuarioBanco.Cpf = usuario.Cpf;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                return RedirectToAction(nameof(Index));

            return View(usuario);
        }

        public IActionResult Deletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                return RedirectToAction(nameof(Index));

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Deletar(Usuario usuario)
        {
            var usuarioBanco = _context.Usuarios.Find(usuario.UsuarioId);

            _context.Usuarios.Remove(usuarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}