using Sistema01.Data;
using Sistema01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sistema01.Controllers
{
    [Route("controller")]
    public class EstoqueController : Controller
    {
        private readonly Sistema01Context _context;

        public EstoqueController(Sistema01Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Layout = "Sistema01";
            return View();
        }
    }
}
