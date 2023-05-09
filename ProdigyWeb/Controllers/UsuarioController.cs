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

        [AllowAnonymous]
        public void AddSessao()
        {
            ViewBag.Id = User.FindFirst("Id")?.Value;
            ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            ViewBag.Nivel = User.FindFirst(ClaimTypes.Role)?.Value;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            ClaimsPrincipal claims = HttpContext.User;
            ViewBag.Layout = "ProdigyWeb";

            if (claims.Identity.IsAuthenticated)
                return View();

            AddSessao();
            return RedirectToAction("Login", "Usuario");
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

        [HttpPost("LoginUsuario"), AllowAnonymous]
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

            return RedirectToAction("Index", "Usuario");
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
            try
            {            
                if (ModelState.IsValid)
                {
                    var usuarios = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

                    string senhaSecreta = hash.CriptografarSenha(usuario.Senha.ToString());

                    if (usuarios == null)
                    {
                        usuario.Senha = senhaSecreta;

                        _context.Usuarios.Add(usuario);
                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (DbUpdateException e)
            {
                ViewBag.ErroCriar = $"Erro ao criar cadastro: {e}";
                return RedirectToAction(nameof(Login));
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