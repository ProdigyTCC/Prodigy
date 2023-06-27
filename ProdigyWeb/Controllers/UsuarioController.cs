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
        private readonly IValidaIdentidade _auth;
        
        public UsuarioController(
                ProdigyWebContext context,
                ICookie cookie,
                IWebHostEnvironment caminhoServidor,
                IValidaIdentidade auth)
        {
            _caminhoServidor = caminhoServidor.WebRootPath;
            _cookie = cookie;
            _context = context;
            _auth = auth;
        }

        [AllowAnonymous]
        private void AddSessao()
            {
                ViewBag.Id = User.FindFirst("Id")?.Value;
                ViewBag.Nome = User.FindFirst(ClaimTypes.Name)?.Value;
                ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;
                ViewBag.Nivel = User.FindFirst(ClaimTypes.Role)?.Value;
            }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? msg)
        {
            ViewBag.Layout = "ProdigyWeb";
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                AddSessao();

                var usuarioId = User.FindFirst("Id").Value;

                var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);
                TempData["Msg"] = msg;
                return View(usuarios);
            }

            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("Login")]
        public IActionResult Login(string? msg)
        {
            AddSessao();
            ViewBag.Layout = "ProdigyWeb";
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Usuario");

            TempData["Msg"] = msg;
            return View();
        }

        [HttpPost("LoginUsuario"), AllowAnonymous]
        public async Task<IActionResult> Login(string Email, string Cnpj, string Nivel, string Senha)
            {
            var usuarios = new Usuario();
            var funcionario = new SFuncionario(); 
                try
                {
                if(Nivel == "Administrador")
                {
                    usuarios = _cookie.ValidarUsuario(Email, Senha);
                }

                if (Nivel == "Funcionario")
                {
                    funcionario = _cookie.ValidarFuncionario(Email, Senha, Cnpj);
                }

                if (usuarios == null)
                {
                    string msg = "Login e/ou senha inválidos!";
                    return RedirectToAction("Login", new {msg});
                }
                else
                {
                    await _cookie.GerarClaim(HttpContext, usuarios);
                }
                if (funcionario != null)
                {
                    string msg = "Login e/ou senha inválidos!";
                    return RedirectToAction("Login", new {msg});
                }
                else
                {
                    await _cookie.GerarClaimFuncionario(HttpContext, funcionario);
                }

                    var usuarioBanco = _context.Usuarios.FirstOrDefault(x => x.Email == Email || x.Cpf == Email);
                    
                    if (string.IsNullOrEmpty(usuarioBanco.Plano)) return RedirectToAction("Planos", "Home");

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Login");
                }
            }

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar(string? msg)
            {
                AddSessao();
                ViewBag.Layout = "ProdigyWeb";
                ClaimsPrincipal claims = HttpContext.User;

                if (claims.Identity.IsAuthenticated)
                    return RedirectToAction("Index");

                TempData["Msg"] = msg;
                return View();
            }

        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(Usuario usuario)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);

                    // var authCpf = _auth.ValidaCpf(usuario.Cpf);

                    string senhaSecreta = hash.CriptografarSenha(usuario.Senha.ToString());

                    if (usuarios != null)
                    {
                        msg = "Email já existe, ou algum campo está incompleto.";
                        return RedirectToAction("Cadastrar", new{msg});
                    }
                    // if (!authCpf)
                    // {
                    //     
                    //     return RedirectToAction(nameof(Cadastrar));
                    // }
                    usuario.Senha = senhaSecreta;
                    usuario.Nivel = "Administrador";
                    usuario.Status = "Ativo";
                    usuario.DataRegistro = DateTime.UtcNow.ToString("dd/MM/yyyy");

                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    msg = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Login", new {msg});
                }
            }
            catch (DbUpdateException e)
            {
                msg = $"Erro ao criar cadastro: {e.Message}";
                return RedirectToAction("Cadastrar", new {msg});
            }
            return RedirectToAction("Cadastrar");
        }

        [HttpGet("Logout"), Authorize]
        public async Task<IActionResult> Logout()
        {
            await _cookie.Logout(HttpContext);
            var msg = "Sessão finalizada";
            return RedirectToAction("Index", "Home", new {msg});
        }

        [HttpPost("UploadImagem")]
        public async Task<IActionResult> UploadImagem(IFormFile? imagem)
        {
            string msg;
            AddSessao();

            if (imagem == null) 
            {
                msg = $"Selecione uma imagem para atualizar o perfil!";
                return RedirectToAction("Index", new {msg});
            }

            string caminhoAddFoto = _caminhoServidor + $"\\Imagem\\";
            string nomeImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName;

            if (!Directory.Exists(caminhoAddFoto))
            {
                Directory.CreateDirectory(caminhoAddFoto);
            }

            using (var stream = System.IO.File.Create(caminhoAddFoto + nomeImagem))
            {
                await imagem.CopyToAsync(stream);
            }

            string usuarioId = ViewBag.Id;
            var usuarioBanco = _context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(x => x.UsuarioId.ToString() == usuarioId);

            try
            {
                usuarioBanco.Imagem = nomeImagem.ToString();
                _context.Usuarios.Update(usuarioBanco);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                msg = $"Falha ao atualizar a imagem! ERRO: [ {e} ]";
                return RedirectToAction("Index", new {msg});
            }
            return RedirectToAction("Index");
        }

        [HttpDelete("DeletarConta")]
        public async Task<IActionResult> DeletarConta(string? id)
        {
            string msg;
            var usuarioId = User.FindFirst("Id")?.Value;
                
            try
            {
                var usuarios = _context.Usuarios.FirstOrDefault(x => x.UsuarioId.ToString() == id);
                _context.Usuarios.Remove(usuarios);
                _context.SaveChanges();
                await _cookie.Logout(HttpContext);
                msg = "O grupo Prodigy agradece a sua utilização!";
                return RedirectToAction("Index", "Home", new {msg});
            }
            catch(DbException e)
            {
                msg = $"Ocorreu um erro ao tentar excluir a conta. Contate o administrador! {e.Message}";
                return RedirectToAction("Index", new {msg});
            }
        }

        [HttpGet("Atualizar/{value?}"), AllowAnonymous]
        public async Task<IActionResult> Atualizar(string? value)
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
            var enderecos = await _context.Enderecos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
            var juridico = await _context.Juridicos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));

            ViewBag.Layout = "ProdigyWeb";
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                if(value == "1") TempData["Msg"] = "Cadastro atualizado com sucesso!";
                if(value == "2") TempData["Msg"] = "Erro ao atualizar o cadastro!";
                value = "0";

                ViewBag.Endereco = enderecos;
                ViewBag.Juridico = juridico;

                AddSessao();
                return View(usuarios);
            }
            return RedirectToAction("Login", "Usuario");
        }
        
        [HttpPost("AtualizarEmpresa")]
        public async Task<IActionResult> AtualizarEmpresa(string NomeRazaoEmpresa, 
            string EmailEmpresa, string TelefoneEmpresa, string CnpjEmpresa,
            string RgMunicipalEmpresa, string RgEstadualEmpresa, string NaturezaEmpresa,
            string DataFundacaoEmpresa, string RuaEmpresa, string NumeroEmpresa, 
            string BairroEmpresa, string ComplementoEmpresa, string CepEmpresa, string CidadeEmpresa, 
            string EstadoEmpresa, string PaisEmpresa)
        {
            var usuarioId = User.FindFirst("Id")?.Value;

            var juridicoBanco = await _context.Juridicos.FirstOrDefaultAsync(x => x.UsuarioId == int.Parse(usuarioId));

            try
            {

                if(juridicoBanco == null)
                {
                    var juridico = new Juridico()
                    {
                        NomeRazao = NomeRazaoEmpresa,
                        Email = EmailEmpresa,
                        Telefone = TelefoneEmpresa,
                        Cnpj = CnpjEmpresa,
                        RgMunicipal = RgMunicipalEmpresa,
                        RgEstadual = RgEstadualEmpresa,
                        Natureza = NaturezaEmpresa,
                        DataFundacao = DataFundacaoEmpresa,
                        Rua = RuaEmpresa,
                        Numero = int.Parse(NumeroEmpresa),
                        Bairro = BairroEmpresa,
                        Complemento = ComplementoEmpresa,
                        Cep = CepEmpresa,
                        Cidade = CidadeEmpresa,
                        Estado = EstadoEmpresa,
                        Pais = PaisEmpresa,
                        UsuarioId = int.Parse(usuarioId)
                    };

                    _context.Juridicos.Add(juridico);
                    _context.SaveChanges();

                    return RedirectToAction("Atualizar");
                }
                if (!string.IsNullOrEmpty(NomeRazaoEmpresa)) juridicoBanco.NomeRazao = NomeRazaoEmpresa;
                if (!string.IsNullOrEmpty(EmailEmpresa)) juridicoBanco.Email = EmailEmpresa;
                if (!string.IsNullOrEmpty(TelefoneEmpresa)) juridicoBanco.Telefone = TelefoneEmpresa;
                if (!string.IsNullOrEmpty(CnpjEmpresa)) juridicoBanco.Cnpj = CnpjEmpresa;
                if (!string.IsNullOrEmpty(RgMunicipalEmpresa)) juridicoBanco.RgMunicipal = RgMunicipalEmpresa;
                if (!string.IsNullOrEmpty(RgEstadualEmpresa)) juridicoBanco.RgEstadual = RgEstadualEmpresa;
                if (!string.IsNullOrEmpty(NaturezaEmpresa)) juridicoBanco.Natureza = NaturezaEmpresa;
                if (!string.IsNullOrEmpty(DataFundacaoEmpresa)) juridicoBanco.DataFundacao = DataFundacaoEmpresa;
                if (!string.IsNullOrEmpty(RuaEmpresa)) juridicoBanco.Rua = RuaEmpresa;
                if (!string.IsNullOrEmpty(NumeroEmpresa)) juridicoBanco.Numero = int.Parse(NumeroEmpresa);
                if (!string.IsNullOrEmpty(BairroEmpresa)) juridicoBanco.Bairro = BairroEmpresa;
                if (!string.IsNullOrEmpty(ComplementoEmpresa)) juridicoBanco.Complemento = ComplementoEmpresa;
                if (!string.IsNullOrEmpty(CepEmpresa)) juridicoBanco.Cep = CepEmpresa;
                if (!string.IsNullOrEmpty(CidadeEmpresa)) juridicoBanco.Cidade = CidadeEmpresa;
                if (!string.IsNullOrEmpty(EstadoEmpresa)) juridicoBanco.Estado = EstadoEmpresa;
                if (!string.IsNullOrEmpty(PaisEmpresa)) juridicoBanco.Pais = PaisEmpresa;

                _context.Juridicos.Update(juridicoBanco);
                _context.SaveChanges();

                return RedirectToAction("Atualizar");
            }
            catch (Exception)
            {
                return RedirectToAction("Atualizar");
            }
        }
        
        [HttpPost("AtualizarConta")]
        public async Task<IActionResult> AtualizarConta(string Nome, 
            string Cpf, string Email, string DataNascimento, 
            string Telefone, string Senha)
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
                        if (!string.IsNullOrEmpty(Telefone)) usuarioBanco.Telefone = Telefone;

                        _context.Usuarios.Update(usuarioBanco);
                        _context.SaveChanges();

                        return RedirectToAction("Atualizar");
                    }
                }
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("AtualizarEndereco")]
        public async Task<IActionResult> AtualizarEndereco(string Rua, 
            string Numero, string Bairro, string Complemento, string Cep, 
            string Cidade, string Estado, string Pais)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioId = User.FindFirst("Id")?.Value;

                    var enderecoBanco = await _context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);

                    if (enderecoBanco != null)
                    {
                        if (!string.IsNullOrEmpty(Rua)) enderecoBanco.Rua = Rua;
                        if (!string.IsNullOrEmpty(Numero)) enderecoBanco.Numero = int.Parse(Numero);
                        if (!string.IsNullOrEmpty(Bairro)) enderecoBanco.Bairro = Bairro;
                        if (!string.IsNullOrEmpty(Complemento)) enderecoBanco.Complemento = Complemento;
                        if (!string.IsNullOrEmpty(Cep)) enderecoBanco.Cep = Cep;
                        if (!string.IsNullOrEmpty(Cidade)) enderecoBanco.Cidade = Cidade;
                        if (!string.IsNullOrEmpty(Estado)) enderecoBanco.Estado = Estado;
                        if (!string.IsNullOrEmpty(Pais)) enderecoBanco.Pais = Pais;

                        _context.Enderecos.Update(enderecoBanco);
                        _context.SaveChanges();

                        return RedirectToAction("Atualizar");
                    }
                    else
                    {
                        var endereco = new Endereco()
                        {
                            Rua = Rua,
                            Numero = int.Parse(Numero),
                            Bairro = Bairro,
                            Complemento = Complemento,
                            Cep = Cep,
                            Cidade = Cidade,
                            Estado = Estado,
                            Pais = Pais,
                            UsuarioId = int.Parse(usuarioId)
                        };

                        _context.Enderecos.Add(endereco);
                        _context.SaveChanges();

                        return RedirectToAction("Atualizar");
                    }
                }
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index");
        }
    }
}