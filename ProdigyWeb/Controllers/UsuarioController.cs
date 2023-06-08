using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Interfaces;
using ProdigyWeb.Models;
using ProdigyWeb.Services;
using System.Data.Common;
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
        private string _caminhoServidor;

        public UsuarioController(
                ProdigyWebContext context,
                ICookie cookie,
                IWebHostEnvironment caminhoServidor)
        {
            _caminhoServidor = caminhoServidor.WebRootPath;
            _cookie = cookie;
            _context = context;
        }

        [AllowAnonymous]
        private void AddSessao()
            {
                ViewBag.Id = User.FindFirst("Id")?.Value;
                ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
                ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            }

        [HttpGet("Index"), AllowAnonymous]
        public async Task<IActionResult> Index()
            {
                ViewBag.Layout = "ProdigyWeb";
                ClaimsPrincipal claims = HttpContext.User;

                if (claims.Identity.IsAuthenticated)
                {
                    var usuarioId = User.FindFirst("Id").Value;

                    var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);

                    AddSessao();
                    return View(usuarios);
                }

                return RedirectToAction("Login", "Usuario");
            }

        [HttpGet("Login")]
        public IActionResult Login()
            {
                ViewBag.Layout = "ProdigyWeb";
                ClaimsPrincipal claims = HttpContext.User;

                if (claims.Identity.IsAuthenticated)
                    return RedirectToAction("Index", "Usuario");

                AddSessao();
                return View();
            }

        [HttpPost("LoginUsuario"), AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
            {
                try
                {
                    var usuarios = _cookie.ValidarUsuario(usuario.Email, usuario.Senha);

                    if (usuarios == null)
                    {
                        TempData["Erro"] = "Login e/ou senha inválidos!";
                        return RedirectToAction(nameof(Index));
                    }

                    await _cookie.GerarClaim(HttpContext, usuarios);

                    var usuarioBanco = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

                    if (string.IsNullOrEmpty(usuarioBanco.Plano)) return RedirectToAction("Planos", "Home");

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Login));
                }
            }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
            {
                ViewBag.Layout = "ProdigyWeb";
                ClaimsPrincipal claims = HttpContext.User;

                if (claims.Identity.IsAuthenticated)
                    return RedirectToAction(nameof(Index));

                AddSessao();

                return View();
            }

        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(Usuario usuario)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);

                        string senhaSecreta = hash.CriptografarSenha(usuario.Senha.ToString());

                        if (usuarios == null)
                        {
                            usuario.Senha = senhaSecreta;
                            usuario.Nivel = "Administrador";
                            usuario.DataRegistro = DateTime.UtcNow.ToString("dd/MM/yyyy");

                            _context.Usuarios.Add(usuario);
                            _context.SaveChanges();
                            TempData["Sucesso"] = "Cadastro realizado com sucesso!";
                            return RedirectToAction(nameof(Login));
                        }
                        else
                        {
                            TempData["Erro"] = "Email já existe, ou algum campo está incompleto.";
                            return RedirectToAction(nameof(Cadastrar));
                        }
                    }
                }
                catch (DbUpdateException e)
                {
                    TempData["Erro"] = $"Erro ao criar cadastro: {e.Message}";
                    return RedirectToAction(nameof(Login));
                }
                return RedirectToAction(nameof(Cadastrar));
            }

        [HttpGet("Logout"), Authorize]
        public async Task<IActionResult> Logout()
            {
                await _cookie.Logout(HttpContext);
                TempData["Sucesso"] = "Sessão finalizada";
                return RedirectToAction("Index", "Home");
            }

        [HttpPost("UploadImagem")]
        public async Task<IActionResult> UploadImagem(IFormFile? imagem)
            {
                AddSessao();

                if (imagem == null) return RedirectToAction(nameof(Index),
                       TempData["Erro"] = $"Selecione uma imagem para atualizar o perfil!");

                string caminhoAddFoto = _caminhoServidor + "\\Imagem\\";
                string nomeImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName;
                string usuarioId = ViewBag.Id;
                var usuarioBanco = _context.Usuarios
                    .AsNoTracking()
                    .FirstOrDefault(x => x.UsuarioId.ToString() == usuarioId);

                if (!Directory.Exists(caminhoAddFoto))
                {
                    Directory.CreateDirectory(caminhoAddFoto);
                }

                using (var stream = System.IO.File.Create(caminhoAddFoto + nomeImagem))
                {
                    await imagem.CopyToAsync(stream);
                }
                try
                {
                    usuarioBanco.Imagem = nomeImagem;
                    _context.Usuarios.Update(usuarioBanco);
                    _context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    return RedirectToAction(nameof(Index),
                        TempData["Erro"] = $"Falha ao atualizar a imagem! ERRO: [ {e} ]");
                }
                return RedirectToAction(nameof(Index));
            }

        [HttpPost("DeletarConta")]
        public async Task<IActionResult> DeletarConta(string id)
            {
                var usuarioId = User.FindFirst("Id")?.Value;
                    
                try
                {
                    var usuarios = _context.Usuarios.FirstOrDefault(x => x.UsuarioId.ToString() == id);
                    _context.Usuarios.Remove(usuarios);
                    _context.SaveChanges();
                    await _cookie.Logout(HttpContext);
                    TempData["Sucesso"] = "O grupo Prodigy agradece a sua utilização!";
                    return RedirectToAction("Index", "Home");
                }
                catch(DbException e)
                {
                    TempData["Erro"] = $"Ocorreu um erro ao tentar excluir a conta. Contate o administrador! {e.Message}";
                    return RedirectToAction(nameof(Index));
                }
            }

        [HttpGet("Atualizar"), AllowAnonymous]
        public async Task<IActionResult> Atualizar(bool? erroAtualizar)
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));

            ViewBag.Layout = "ProdigyWeb";
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                if(erroAtualizar == true) TempData["Sucesso"] = "Cadastro atualizado com sucesso!";

                AddSessao();
                return View(usuarios);
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AtualizarConta")]
        public async Task<IActionResult> AtualizarConta(string Nome, string Cpf, string Email, string DataNascimento, string Senha)
        {   
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioId = User.FindFirst("Id")?.Value;
                    var senhaSecreta = "";
                    var usuarioBanco = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);

                    if (usuarioBanco != null)
                    {
                        if (!string.IsNullOrEmpty(Senha))
                        {
                            senhaSecreta = hash.CriptografarSenha(Senha.ToString());
                            usuarioBanco.Senha = senhaSecreta;
                        }

                        if (!string.IsNullOrEmpty(Nome)) usuarioBanco.Nome = Nome;
                        if (!string.IsNullOrEmpty(Cpf)) usuarioBanco.Cpf = Cpf;
                        if (!string.IsNullOrEmpty(Email)) usuarioBanco.Email = Email;
                        if (!string.IsNullOrEmpty(DataNascimento)) usuarioBanco.DataNascimento = DataNascimento;

                        _context.Usuarios.Update(usuarioBanco);
                        _context.SaveChanges();

                        return RedirectToAction("Atualizar", new { erroAtualizar = true});
                    }
                }
            }
            catch (DbUpdateException e)
            {
                TempData["Erro"] = $"Erro ao atualizar o cadastro: {e.Message}";
                return RedirectToAction(nameof(Login));
            }
            TempData["Erro"] = "Os valores enviados estão vazios!";
            return RedirectToAction(nameof(Index));
        }
    }
}