using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Interfaces;
using ProdigyWeb.Models;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ProdigyWeb.Services
{
    public class CookieService : ICookie
    {
        HashService hash = new HashService(SHA256.Create());
        private readonly ProdigyWebContext _context;
        public CookieService(
            ProdigyWebContext context)
        {
            _context = context;
        }
        public async Task GerarClaim(HttpContext context, Usuario usuario)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", usuario.UsuarioId.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
            claims.Add(new Claim(ClaimTypes.Role, usuario.Nivel));

            var claimsIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    )
                );

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsIdentity,
                authProperties);
        }

        public async Task GerarClaimFuncionario(HttpContext context, SFuncionario funcionario)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", funcionario.UsuarioId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, funcionario.Nome));
            claims.Add(new Claim(ClaimTypes.Role, funcionario.Nivel));

            var claimsIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    )
                );

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsIdentity,
                authProperties);
        }
        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public Usuario ValidarUsuario(string email, string senha)
        {
            var senhaCriptografada = hash.CriptografarSenha(senha);

            var usuario = _context.Usuarios.Where(
                x => x.Email == email &&
                x.Senha == senhaCriptografada).FirstOrDefault();

            return usuario;
        }

        public SFuncionario ValidarFuncionario(string email, string senha, string cnpj)
        {
            var senhaCriptografada = hash.CriptografarSenha(senha);

            var empresa = _context.Juridicos.Where(
                x => x.Cnpj == cnpj).FirstOrDefault();

            var funcionario = _context.SFuncionarios.FirstOrDefault(
                x => x.Email == email &&
                x.Senha == senhaCriptografada && x.UsuarioId == empresa.UsuarioId);
              
            return funcionario;
        }
    }
}
