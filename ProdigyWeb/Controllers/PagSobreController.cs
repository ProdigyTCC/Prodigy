using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdigyWeb.Data;
using ProdigyWeb.Models;

namespace ProdigyWeb.Controllers
{
    [Route("[controller]")]
    public class PagSobreController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}