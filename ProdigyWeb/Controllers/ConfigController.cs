using Microsoft.AspNetCore.Mvc;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("controller")]
    public class ConfigController : Controller
    {
        private readonly ProdigyWebContext _context;

        public ConfigController(ProdigyWebContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var config = _context.Configs.ToList();
            return View(config);
        }
        [HttpPost]
        public IActionResult Criar(Config config)
        {
            if (ModelState.IsValid)
            {
                _context.Configs.Add(config);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(config);
        }

        public IActionResult Editar(int id)
        {
            var config = _context.Configs.Find(id);

            if (config == null)
                return RedirectToAction(nameof(Index));

            return View(config);
        }

        [HttpPost]
        public IActionResult Editar(Config config)
        {
            var configBanco = _context.Configs.Find(config.ConfigId);

            configBanco.Tema = config.Tema;

            _context.Configs.Update(configBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var config = _context.Configs.Find(id);

            if (config == null)
                return RedirectToAction(nameof(Index));

            return View(config);
        }

        public IActionResult Deletar(int id)
        {
            var config = _context.Configs.Find(id);

            if (config == null)
                return RedirectToAction(nameof(Index));

            return View(config);
        }

        [HttpPost]
        public IActionResult Deletar(Config config)
        {
            var configBanco = _context.Configs.Find(config.ConfigId);

            _context.Configs.Remove(configBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
