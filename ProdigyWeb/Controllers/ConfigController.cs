using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class ConfigController : Controller
    {
        private readonly ProdigyWebContext _context;
        private string _caminhoServidor;
        public ConfigController(ProdigyWebContext context, IWebHostEnvironment caminhoServidor)
        {
            _context = context;
            _caminhoServidor = caminhoServidor.WebRootPath;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                var config = await _context.Configs.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);

                if (config == null) return View();
                ViewBag.Config = config;
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddConfig")]
        public async Task<IActionResult> AddConfig(Config config, IFormFile? arquivo)
        {
            try{
                if (ModelState.IsValid)
                {
                    var usuarioId = User.FindFirst("Id")?.Value;

                    var configBanco = await _context.Configs.FirstOrDefaultAsync(x => x.UsuarioId.ToString() == usuarioId);
                    if (arquivo == null)
                    {
                        TempData["Erro"] = $"Selecione uma arquivo para atualizar o perfil!";
                        return RedirectToAction(nameof(Index));
                    }

                    string caminhoAddFoto = _caminhoServidor + $"\\Arquivo\\";
                    string nomeArquivo = Guid.NewGuid().ToString() + "_" + arquivo.FileName;

                    if (!Directory.Exists(caminhoAddFoto))
                    {
                        Directory.CreateDirectory(caminhoAddFoto);
                    }

                    using (var stream = System.IO.File.Create(caminhoAddFoto + nomeArquivo))
                    {
                        await arquivo.CopyToAsync(stream);
                    }
                    if (configBanco != null)
                    {
                        if (!string.IsNullOrEmpty(config.PorcentagemLucro)) configBanco.PorcentagemLucro = config.PorcentagemLucro;
                        if (!string.IsNullOrEmpty(config.PorcentagemDesconto)) configBanco.PorcentagemDesconto = config.PorcentagemDesconto;
                        if (!string.IsNullOrEmpty(config.TaxaParcela)) configBanco.TaxaParcela = config.TaxaParcela;
                        if (!string.IsNullOrEmpty(config.TaxaDebito)) configBanco.TaxaDebito = config.TaxaDebito;
                        if (!string.IsNullOrEmpty(config.TaxaCredito)) configBanco.TaxaCredito = config.TaxaCredito;
                        if (!string.IsNullOrEmpty(config.NfEletronica)) configBanco.NfEletronica = nomeArquivo;

                        _context.Configs.Update(configBanco);
                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        config.UsuarioId = int.Parse(usuarioId);
                        config.NfEletronica = nomeArquivo;

                        _context.Configs.Add(config);
                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction("Index", "SEstoque");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}