using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;
using System.Data.Common;
using System.Security.Claims;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SFornecedorController : Controller
    {
        private readonly ProdigyWebContext _context;

        public SFornecedorController(ProdigyWebContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? nome = "")
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;
            if (claims.Identity.IsAuthenticated)
            {
                var fornecedores = _context.SFornecedores.Where(x => x.UsuarioId == int.Parse(usuarioId));

                if (nome != "")
                {
                    fornecedores = fornecedores.Where(x => x.SFornecedorId.ToString() == nome || x.NomeRazao.Contains(nome));
                    ViewBag.Layout = "Dashboard";

                    return View(fornecedores);
                }
                ViewBag.Layout = "Dashboard";
                return View(fornecedores);
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddFornecedor")]
        public IActionResult AddFornecedor()
        {
            ClaimsPrincipal claims = HttpContext.User;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddFornecedorBanco")]
        public async Task<IActionResult> AddFornecedorBanco(SFornecedor fornecedor)
        {
            var usuarioId = User.FindFirst("Id")?.Value;

            var fornecedorBanco = await _context.SFornecedores.FirstOrDefaultAsync(x => x.Cnpj.Equals(fornecedor.Cnpj) &&
                x.UsuarioId.ToString().Equals(usuarioId));
            try
            {
                if(fornecedorBanco == null)
                {
                    fornecedor.UsuarioId = int.Parse(usuarioId);
                    fornecedor.DataRegistro = DateTime.UtcNow.ToString("dd/MM/yyyy");

                    _context.SFornecedores.Add(fornecedor);
                    _context.SaveChanges();

                    TempData["Sucesso"] = "Fornecedor cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                
                TempData["Erro"] = "Este fornecedor já existe em seu sistema!";
                return RedirectToAction(nameof(AddFornecedor));
            }
            catch(DbException)
            {
                TempData["Erro"] = "Erro ao cadastrar o fornecedor";
                return RedirectToAction(nameof(AddFornecedor));
            }
        }
    
        [HttpGet("Editar")]
        public async Task<IActionResult> Editar(int? id)
        {
            var fornecedor = await _context.SFornecedores.FirstOrDefaultAsync(x => x.SFornecedorId.Equals(id));

            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                if (fornecedor != null)
                {
                    ViewBag.Layout = "Dashboard";
                    return View(fornecedor);
                }
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }
    
        [HttpPost("EditarFornecedor")]
        public async Task<IActionResult> EditarFornecedor(SFornecedor fornecedor)
        {
            var usuarioId = User.FindFirst("Id")?.Value;

            var fornecedorBanco = await _context.SFornecedores.FirstOrDefaultAsync(x => x.UsuarioId.ToString().Equals(usuarioId));

            try
            {
                if (fornecedorBanco != null)
                {

                    if(!string.IsNullOrEmpty(fornecedor.NomeRazao)) fornecedorBanco.NomeRazao = fornecedor.NomeRazao;
                    if(!string.IsNullOrEmpty(fornecedor.Cnpj)) fornecedorBanco.Cnpj = fornecedor.Cnpj;
                    if(!string.IsNullOrEmpty(fornecedor.Email)) fornecedorBanco.Email = fornecedor.Email;
                    if(!string.IsNullOrEmpty(fornecedor.Telefone)) fornecedorBanco.Telefone = fornecedor.Telefone;
                    if(!string.IsNullOrEmpty(fornecedor.CpfRepresentante)) fornecedorBanco.CpfRepresentante = fornecedor.CpfRepresentante;
                    if(!string.IsNullOrEmpty(fornecedor.RgEstadual)) fornecedorBanco.RgEstadual = fornecedor.RgEstadual;
                    if(!string.IsNullOrEmpty(fornecedor.RgMunicipal)) fornecedorBanco.RgMunicipal = fornecedor.RgMunicipal;
                    if(!string.IsNullOrEmpty(fornecedor.DataFundacao)) fornecedorBanco.DataFundacao = fornecedor.DataFundacao;
                    if(!string.IsNullOrEmpty(fornecedor.NomeRepresentante)) fornecedorBanco.NomeRepresentante = fornecedor.NomeRepresentante;

                    if (!string.IsNullOrEmpty(fornecedor.Rua)) fornecedorBanco.Rua = fornecedor.Rua;
                    if (!string.IsNullOrEmpty(fornecedor.Numero)) fornecedorBanco.Numero = fornecedor.Numero;
                    if (!string.IsNullOrEmpty(fornecedor.Bairro)) fornecedorBanco.Bairro = fornecedor.Bairro;
                    if (!string.IsNullOrEmpty(fornecedor.Complemento)) fornecedorBanco.Complemento = fornecedor.Complemento;
                    if (!string.IsNullOrEmpty(fornecedor.Cep)) fornecedorBanco.Cep = fornecedor.Cep;
                    if (!string.IsNullOrEmpty(fornecedor.Cidade)) fornecedorBanco.Cidade = fornecedor.Cidade;
                    if (!string.IsNullOrEmpty(fornecedor.Estado)) fornecedorBanco.Estado = fornecedor.Estado;
                    if (!string.IsNullOrEmpty(fornecedor.Pais)) fornecedorBanco.Pais = fornecedor.Pais;

                    _context.SFornecedores.Update(fornecedorBanco);
                    _context.SaveChanges();

                    TempData["Sucesso"] = "fornecedor atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Erro"] = "Erro ao atualizar o fornecedor!\nTente novamente.";
                return RedirectToAction(nameof(Editar));
            }
            catch (DbException)
            {
                TempData["Erro"] = "Erro cadastrar o fornecedor";
                return RedirectToAction(nameof(Editar));
            }
        }
    }
}
