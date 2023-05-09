using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Interfaces;
using ProdigyWeb.Models;
using ProdigyWeb.Services;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        HashService hash = new HashService(SHA256.Create());
        private readonly ProdigyWebContext _context;
        private readonly ICookie _cookie;

        public UsuarioController(
            ProdigyWebContext context,
            ICookie cookie)
        {
            _cookie = cookie;
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.Layout = "ProdigyWeb";
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login(bool erroLogin)
        {
            ClaimsPrincipal claims = HttpContext.User;
            if (erroLogin) ViewBag.Erro = "Login e/ou senha inválidos!";

            if (claims.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Usuario");

            ViewBag.Layout = "ProdigyWeb";
            return View();
        }

        [HttpPost("LoginUsuario")]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (usuario.Email == null || usuario.Senha == null)
            {
                return RedirectToAction("Index", new { erroLogin = true });
            }

            var usuarios = _cookie.ValidarUsuario(usuario.Email, usuario.Senha);

            if (usuarios == null)
            {
                return RedirectToAction("Index", new { erroLogin = true });
            }

            await _cookie.GerarClaim(HttpContext, usuarios);

            return RedirectToAction("Index", "Tarefa");
        }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar(bool erroCadastro)
        {
            ClaimsPrincipal claims = HttpContext.User;

            if (erroCadastro) TempData["ErroLogin"] = "Email já existe, ou algum campo está incompleto.";

            if (claims.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Usuario");

            ViewBag.Layout = "ProdigyWeb";

            return View();
        }

        [HttpPost("CadastrarUsuario")]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            var usuarios = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

            string senhaSecreta = hash.CriptografarSenha(usuario.Senha.ToString());

            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Senha = senhaSecreta;
                
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException e)
            {
                TempData["DbErro"] = $"Erro ao criar cadastro: {e}";
                return RedirectToAction(nameof(Cadastrar));
            }
            return RedirectToAction("Cadastrar", new { erroCadastro = true }); ;
        }

        [HttpGet("Logout"), Authorize]
        public async Task<IActionResult> Logout()
        {
            await _cookie.Logout(HttpContext);
            return RedirectToAction("Index");
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