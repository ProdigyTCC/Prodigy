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
        public IActionResult Index(string? msg, string? nome = "")
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
                    if (produtos != null) return View(produtos);
                    else View();
                }
                TempData["Msg"] = msg;
                return View(produtos);
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpGet("AddProduto")]
        public async Task<IActionResult> AddProduto(string? msg)
        {
            ClaimsPrincipal claims = HttpContext.User;
            var usuarioId = User.FindFirst("Id")?.Value;

            if (claims.Identity.IsAuthenticated)
            {
                var categProduto = await _context.SCategoriaProdutos.Where(x => x.UsuarioId.ToString() == usuarioId).ToListAsync();

                ViewBag.CategProduto = categProduto;
                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost("AddProdutoBanco")]
        public async Task<IActionResult> AddProdutoBanco(SProduto produto, IFormFile? imagem) 
        {
            string msg;
            
            var usuarioId = User.FindFirst("Id")?.Value;
            if (imagem == null)
            {
                msg = $"Selecione uma arquivo para adicionar foto ao produto!";
                return RedirectToAction(nameof(AddProduto), new {msg});
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

                    msg = "Produto cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }
                produtoBanco.QuantProduto = produto.QuantProduto;
                produtoBanco.Imagem = nomeImagem;

                _context.SProdutos.Update(produto);
                _context.SaveChanges();

                msg = "Este produto já existe em seu estoque!\nEntão atualizamos esse item.";
                return RedirectToAction(nameof(AddProduto), new {msg});
            }
            catch(DbException)
            {
                msg = "Erro cadastrar o produto";
                return RedirectToAction(nameof(AddProduto), new {msg});
            }
        }

        [HttpPost("AddCategoriaProduto")]
        public async Task<IActionResult> AddCategoriaProduto(string nome, string descCategoria)
        {
            string msg;

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
                    msg = "Categoria cadastrada com sucesso!";
                    return RedirectToAction(nameof(Index), new {msg});
                }
                msg = "Esta categoria já existe!";
                return RedirectToAction(nameof(Index), new {msg});
            }
            catch (DbException)
            {
                msg = "Erro ao cadastrar no banco";
                return RedirectToAction(nameof(Index), new {msg});
            }
        }

        [HttpGet("Editar")]
        public async Task<IActionResult> Editar(string? msg, int? id)
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
                    TempData["Msg"] = msg;
                    return View(produtos);
                }
                ViewBag.Layout = "Dashboard";
                TempData["Msg"] = msg;
                return View();
            }
            return RedirectToAction("Login", "Usuario");

        }
        [HttpPost("EditarProduto")]
        public async Task<IActionResult> EditarProduto(SProduto produto, IFormFile? imagem)
        {
            string msg;

            var usuarioId = User.FindFirst("Id")?.Value;
            if (imagem == null)
            {
                msg = $"Selecione uma arquivo para atualizar a foto do produto!";
                return RedirectToAction(nameof(AddProduto), new {msg});
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

                    msg = "Produto atualizado com sucesso!";
                    return RedirectToAction("Index", "SEstoque", new {msg});
                }
                msg = "Erro ao atualizar o produto!\nTente novamente.";
                return RedirectToAction(nameof(Editar), new {msg});
            }
            catch (DbException)
            {
                msg = "Erro cadastrar o produto";
                return RedirectToAction(nameof(Editar), new {msg});
            }
        }

    }
}
