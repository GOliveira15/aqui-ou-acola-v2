using AquiOuAcola.Entidades;
using AquiOuAcola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AquiOuAcola.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto db;
        public HomeController(ILogger<HomeController> logger, Contexto _contexto)
        {
            _logger = logger;
            db = _contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            var Id_Usuario = Int32.Parse(claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Sid).Value);

            List<CursoF> model = db.CursoF.Where(a => a.UsuarioId == Id_Usuario).Include(a => a.Curso).Include(a => a.Usuario).ToList();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
