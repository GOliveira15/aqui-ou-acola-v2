using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquiOuAcola.Entidades;

namespace AquiOuAcola.Controllers
{
    public class CursoFavoritoController : Controller
    {
        private readonly Contexto db;

        public CursoFavoritoController(Contexto contexto)
        {
            db = contexto;
        }

        public IActionResult Favoritar()
        {
            return View();
        }

        public IActionResult Add(int id, CursoF collection)
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;

            if (claimsIdentity != null)
            {
                var IdUsuario = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Sid).Value;

                CursoF _cursof = new CursoF();

                _cursof.UsuarioId = Int32.Parse(IdUsuario);
                _cursof.CursoId = id;

                db.CursoF.Add(_cursof);
                db.SaveChanges();
            }

            return Redirect("/Cursos");
        }
    }
}
