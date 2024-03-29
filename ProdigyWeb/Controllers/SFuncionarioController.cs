﻿using Microsoft.AspNetCore.Mvc;
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
    public class SFuncionarioController : Controller
    {
        private readonly ProdigyWebContext _context;
        private string _caminhoServidor;
        HashService hash = new HashService(SHA256.Create());
        public SFuncionarioController(ProdigyWebContext context, 
            IWebHostEnvironment caminhoServidor)
        {
            _caminhoServidor = caminhoServidor.WebRootPath;
            _context = context;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? msg, string? nome = "")
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;
            var funcionarios = await _context.SFuncionarios.Where(x => x.UsuarioId.Equals(int.Parse(usuarioId))).ToListAsync();

            if (claims.Identity.IsAuthenticated)
            {
                var moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                ViewBag.Layout = "Dashboard";
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }
                if (nome != "")
                {
                    funcionarios = funcionarios.Where(x => x.SFuncionarioId.ToString() == nome || x.Nome.Contains(nome)).ToList();

                    if(funcionarios != null) return View(funcionarios);
                }
                TempData["Msg"] = msg;
                if(funcionarios != null) return View(funcionarios);

                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddFuncionario")]
        public async Task<IActionResult> AddFuncionario(string? msg)
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }

                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddFuncionario")]
        public async Task<IActionResult> AddFuncionario(SFuncionario? funcionario, IFormFile imagem)
        {
            string msg;

            string senha = "";
            if (imagem == null) 
            {
                msg = "Erro ao adicionar a Imagem!\nTente novamente.";
                return RedirectToAction(nameof(AddFuncionario), new {msg});
            }
            var usuarioId = User.FindFirst("Id")?.Value;

            var funcionarioBanco = await _context.SFuncionarios.FirstOrDefaultAsync(x => x.Cpf.Equals(funcionario.Cpf) &&
                x.UsuarioId.ToString().Equals(usuarioId));

            string caminhoImagem = _caminhoServidor + "\\Imagem\\";
            string nomeImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName;

            if (!Directory.Exists(caminhoImagem))
            {
                Directory.CreateDirectory(caminhoImagem);
            }

            using (var stream = System.IO.File.Create(caminhoImagem + nomeImagem))
            {
                await imagem.CopyToAsync(stream);
            }
            try
            {
                if(funcionarioBanco == null)
                {
                    if(funcionario.Senha != null)
                    {
                        senha = hash.CriptografarSenha(funcionario.Senha);
                    }

                    funcionario.Imagem = nomeImagem;
                    funcionario.UsuarioId = int.Parse(usuarioId);
                    funcionario.Senha = senha;
                    funcionario.DataRegistro = DateTime.UtcNow.ToString("dd/MM/yyyy");

                    _context.SFuncionarios.Add(funcionario);
                    _context.SaveChanges();

                    msg = "Funcionário cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }
                
                msg = "Este funcionário já existe em seu sistema!";
                return RedirectToAction(nameof(AddFuncionario), new {msg});
            }
            catch(DbException)
            {
                msg = "Erro ao cadastrar o funcionário";
                return RedirectToAction(nameof(AddFuncionario), new {msg});
            }
        }
    
        [HttpGet("Editar")]
        public async Task<ActionResult> Editar(string? msg, int? id)
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            var funcionarios = await _context.SFuncionarios.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)) && 
                x.SFuncionarioId.Equals(id));

            if (claims.Identity.IsAuthenticated)
            {
                var moduloBanco = await _context.Modulos.FirstOrDefaultAsync(x => x.UsuarioId.Equals(int.Parse(usuarioId)));
                if (moduloBanco != null)
                {
                    if (moduloBanco.NomeSistema == "AcessoPedido")
                        ViewBag.Modulo = "AcessoPedido";
                }

                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                if(id != null) return View(funcionarios);

                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("EditarFuncionario")]
        public async Task<ActionResult> EditarFuncionario(SFuncionario funcionario, IFormFile? imagem)
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            string senha = "";
            string msg;

            var funcionarioBanco = await _context.SFuncionarios.FirstOrDefaultAsync(x => x.UsuarioId.ToString().Equals(usuarioId) && 
                x.SFuncionarioId == funcionario.SFuncionarioId);

            try
            {
                if (funcionarioBanco != null)
                {
                    if (funcionario.Senha != null)
                    {
                        senha = hash.CriptografarSenha(funcionario.Senha);
                    }
                    if (imagem == null) 
                    {
                        msg = "Erro ao atualizar a Imagem!\nTente novamente.";
                        return RedirectToAction(nameof(Editar), new {msg});
                    }
                    string caminhoImagem = _caminhoServidor + "\\Imagem\\";
                    string nomeImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName;

                    if (!Directory.Exists(caminhoImagem))
                    {
                        Directory.CreateDirectory(caminhoImagem);
                    }

                    using (var stream = System.IO.File.Create(caminhoImagem + nomeImagem))
                    {
                        await imagem.CopyToAsync(stream);
                    }
                    funcionario.Imagem = nomeImagem;

                    if(funcionario.Nome != null) funcionarioBanco.Nome = funcionario.Nome;
                    if(funcionario.Cpf != null) funcionarioBanco.Cpf = funcionario.Cpf;
                    if(funcionario.Nivel != funcionarioBanco.Nivel) funcionarioBanco.Nivel = funcionario.Nivel;
                    if(funcionario.Sexo != null) funcionarioBanco.Sexo = funcionario.Sexo;
                    if(funcionario.QtFilhos != funcionarioBanco.QtFilhos) funcionarioBanco.QtFilhos = funcionario.QtFilhos;
                    if(funcionario.DataPagamento != null) funcionarioBanco.DataPagamento = funcionario.DataPagamento;
                    if(funcionario.DataNascimento != null) funcionarioBanco.DataNascimento = funcionario.DataNascimento;
                    if(funcionario.Email != null) funcionarioBanco.Email = funcionario.Email;
                    if(funcionario.Imagem != null) funcionarioBanco.Imagem = funcionario.Imagem;
                    if(funcionario.Telefone != null) funcionarioBanco.Telefone = funcionario.Telefone;
                    if(funcionario.Habilitacao != null) funcionarioBanco.Habilitacao = funcionario.Habilitacao;
                    if(funcionario.Salario != null) funcionarioBanco.Salario = funcionario.Salario;
                    if(funcionario.Observacao != null) funcionarioBanco.Observacao = funcionario.Observacao;
                    if(funcionario.Senha != null) funcionarioBanco.Senha = senha; 

                    if (!string.IsNullOrEmpty(funcionario.Rua)) funcionarioBanco.Rua = funcionario.Rua;
                    if (!string.IsNullOrEmpty(funcionario.Numero)) funcionarioBanco.Numero = funcionario.Numero;
                    if (!string.IsNullOrEmpty(funcionario.Bairro)) funcionarioBanco.Bairro = funcionario.Bairro;
                    if (!string.IsNullOrEmpty(funcionario.Complemento)) funcionarioBanco.Complemento = funcionario.Complemento;
                    if (!string.IsNullOrEmpty(funcionario.Cep)) funcionarioBanco.Cep = funcionario.Cep;
                    if (!string.IsNullOrEmpty(funcionario.Cidade)) funcionarioBanco.Cidade = funcionario.Cidade;
                    if (!string.IsNullOrEmpty(funcionario.Estado)) funcionarioBanco.Estado = funcionario.Estado;
                    if (!string.IsNullOrEmpty(funcionario.Pais)) funcionarioBanco.Pais = funcionario.Pais;

                    _context.SFuncionarios.Update(funcionarioBanco);
                    _context.SaveChanges();

                    msg = "Funcionario atualizado com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }
                msg = "Erro ao atualizar o Funcionario!\nTente novamente.";
                return RedirectToAction(nameof(Editar), new {msg});
            }
            catch (DbException)
            {
                msg = "Erro cadastrar o Funcionario";
                return RedirectToAction(nameof(Editar), new {msg});
            }
        }
    }
}
