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
        

    }
}
