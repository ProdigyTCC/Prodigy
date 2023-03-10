using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class PedidoController : Controller
    {
        private readonly Sistema01Context _context;

        public PedidoController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pedido = _context.Pedidos.ToList();
            return View(pedido);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }
        public IActionResult Editar(int id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (pedido == null)
                return RedirectToAction(nameof(Index));

            return View(pedido);
        }

        [HttpPost]
        public IActionResult Editar(Pedido pedido)
        {
            var pedidoBanco = _context.Pedidos.Find(pedido.PedidoId);

            pedidoBanco.DataPedido = pedido.DataPedido;
            pedidoBanco.DataEntrega = pedido.DataEntrega;
            pedidoBanco.QuantProduto = pedido.QuantProduto;
            pedidoBanco.ValorPedido = pedido.ValorPedido;
            pedidoBanco.NotaFiscal = pedido.NotaFiscal;

            _context.Pedidos.Update(pedidoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (pedido == null)
                return RedirectToAction(nameof(Index));

            return View(pedido);
        }

        public IActionResult Deletar(int id)
        {
            var pedidos = _context.Pedidos.Find(id);

            if (pedidos == null)
                return RedirectToAction(nameof(Index));

            return View(pedidos);
        }
        [HttpPost]
        public IActionResult Deletar(Pedido pedido)
        {
            var pedidoBanco = _context.Pedidos.Find(pedido.PedidoId);

            _context.Pedidos.Remove(pedidoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
