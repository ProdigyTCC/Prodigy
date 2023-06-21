using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Data;
using ProdigyWeb.Models;
using System.Data.Common;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class SEstoqueController : Controller
    {
        private readonly ProdigyWebContext _context;
        private string _caminhoServidor;
        public SEstoqueController(ProdigyWebContext context,
            IWebHostEnvironment caminhoServidor)
        {
            _caminhoServidor = caminhoServidor.WebRootPath;
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index(string? nome = "")
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                ViewBag.Layout = "Dashboard";
                var produtos = _context.SProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToList();

                if (nome != "")
                {
                    produtos = produtos.Where(x => x.SProdutoId.ToString() == nome || x.Nome.Contains(nome)).ToList();
                    if(produtos != null) return View(produtos);
                }
                return View(produtos);
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddProduto")]
        public async Task<IActionResult> AddProduto()
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var categProduto = await _context.SCategoriaProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToListAsync();

                ViewBag.CategProduto = categProduto;
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddProdutoBanco")]
        public async Task<IActionResult> AddProdutoBanco(SProduto produto, IFormFile? imagem) 
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            if (imagem == null)
            {
                TempData["Erro"] = $"Selecione uma arquivo para adicionar foto ao produto!";
                return RedirectToAction(nameof(AddProduto));
            }
            var produtoBanco = await _context.SProdutos.FirstOrDefaultAsync(x => x.Nome.Equals(produto.Nome) &&
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
                if(produtoBanco == null)
                {
                    produto.Imagem = nomeImagem;
                    produto.UsuarioId = int.Parse(usuarioId);

                    _context.SProdutos.Add(produto);
                    _context.SaveChanges();

                    TempData["Sucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                produtoBanco.QuantProduto = produto.QuantProduto;
                produtoBanco.Imagem = nomeImagem;

                _context.SProdutos.Update(produto);
                _context.SaveChanges();

                TempData["Erro"] = "Este produto já existe em seu estoque!\nEntão atualizamos esse item.";
                return RedirectToAction(nameof(AddProduto));
            }
            catch(DbException)
            {
                TempData["Erro"] = "Erro cadastrar o produto";
                return RedirectToAction(nameof(AddProduto));
            }
        }

        [HttpPost("AddCategoriaProduto")]
        public async Task<IActionResult> AddCategoriaProduto(string nome, string descCategoria)
        {
            var usuarioId = User.FindFirst("Id")?.Value;

            var categProdutosBanco = await _context.SCategoriaProdutos.Where(x => x.Nome.Equals(nome) && 
                x.UsuarioId.ToString().Equals(usuarioId)).FirstOrDefaultAsync();

            var categProduto = new SCategoriaProduto()
            {
                Nome = nome,
                DescCategoria = descCategoria,
                UsuarioId = int.Parse(usuarioId)
            };

            try
            {
                if(categProdutosBanco == null)
                {
                    _context.SCategoriaProdutos.Add(categProduto);
                    _context.SaveChanges();
                    TempData["Sucesso"] = "Categoria cadastrada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Erro"] = "Esta categoria já existe!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbException)
            {
                TempData["Erro"] = "Erro ao cadastrar no banco";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("Editar")]
        public async Task<IActionResult> Editar(int? id)
        {
            var produtos = await _context.SProdutos.FirstOrDefaultAsync(x => x.SProdutoId.Equals(id));

            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                if (produtos != null)
                {
                    var categProduto = await _context.SCategoriaProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToListAsync();

                    ViewBag.CategProduto = categProduto;
                    ViewBag.Layout = "Dashboard";
                    return View(produtos);
                }
                ViewBag.Layout = "Dashboard";
                return View();
            }
            return RedirectToAction("Login", "Usuario");

        }
        [HttpPost("EditarProduto")]
        public async Task<IActionResult> EditarProduto(SProduto produto, IFormFile? imagem)
        {
            var usuarioId = User.FindFirst("Id")?.Value;
            if (imagem == null)
            {
                TempData["Erro"] = $"Selecione uma arquivo para atualizar a foto do produto!";
                return RedirectToAction(nameof(AddProduto));
            }
            var produtoBanco = await _context.SProdutos.FirstOrDefaultAsync(x => x.UsuarioId.ToString().Equals(usuarioId));

            try
            {
                if (produtoBanco != null)
                {
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
                    produto.Imagem = nomeImagem;

                    if(produto.Nome != null) produtoBanco.Nome = produto.Nome;
                    if(produto.DescProduto != null) produtoBanco.DescProduto = produto.DescProduto;
                    if(produto.QuantProduto != produtoBanco.QuantProduto) produtoBanco.QuantProduto = produto.QuantProduto;
                    if(produto.Marca != null) produtoBanco.Marca = produto.Marca;
                    if(produto.SCategoriaProdutoId != produtoBanco.SCategoriaProdutoId) produtoBanco.SCategoriaProdutoId = produto.SCategoriaProdutoId;
                    if(produto.Imagem != null) produtoBanco.Imagem = produto.Imagem;
                    if(produto.DataValidade != null) produtoBanco.DataValidade = produto.DataValidade;
                    if(produto.DataEntrada != null) produtoBanco.DataEntrada = produto.DataEntrada;
                    if(produto.ValorInicial != null) produtoBanco.ValorInicial = produto.ValorInicial;
                    if(produto.ValorFinal != null) produtoBanco.ValorFinal = produto.ValorFinal;

                    _context.SProdutos.Update(produtoBanco);
                    _context.SaveChanges();

                    TempData["Sucesso"] = "Produto atualizado com sucesso!";
                    return RedirectToAction("Index", "SEstoque");
                }
                TempData["Erro"] = "Erro ao atualizar o produto!\nTente novamente.";
                return RedirectToAction(nameof(Editar));
            }
            catch (DbException)
            {
                TempData["Erro"] = "Erro cadastrar o produto";
                return RedirectToAction(nameof(Editar));
            }
        }

    }
}
