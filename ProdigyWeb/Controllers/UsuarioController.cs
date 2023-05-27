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
            public void AddSessao()
            {
                ViewBag.Id = User.FindFirst("Id")?.Value;
                ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
                ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            }

            [HttpGet("Index"), AllowAnonymous]
            public IActionResult Index()
            {
                ViewBag.Layout = "ProdigyWeb";
                ClaimsPrincipal claims = HttpContext.User;

                if (claims.Identity.IsAuthenticated)
                {
                    var usuarioId = User.FindFirst("Id").Value;

                    var usuarios = _context.Usuarios
                    .Where(x => x.UsuarioId.ToString() == usuarioId).ToList();

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

                            return RedirectToAction("Planos", "Home");
                        }
                        else
                        {
                            TempData["Erro"] = "Email j\u00e1 existe, ou algum campo est\u00e1 incompleto.";
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
                return RedirectToAction(nameof(Index));
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
            public async Task<IActionResult> DeletarConta()
            {
                var usuarioId = User.FindFirst("Id")?.Value;
                    
                try
                {
                    var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);
                    await _cookie.Logout(HttpContext);
                    _context.Usuarios.Remove(usuarios);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Login));
                }
                catch(DbException e)
                {
                    TempData["Erro"] = $"Ocorreu um erro ao tentar excluir a conta. Contate o administrador! {e.Message}";
                    return RedirectToAction(nameof(Index));
                }
            }
        }
}