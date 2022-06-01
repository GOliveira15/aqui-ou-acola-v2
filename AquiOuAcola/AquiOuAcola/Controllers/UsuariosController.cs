using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquiOuAcola.Entidades;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace AquiOuAcola.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto db;
        private string caminhoServidor;

        public UsuariosController(Contexto contexto, IWebHostEnvironment sistema)
        {
            db = contexto;
            caminhoServidor = sistema.WebRootPath;
        }


        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios collection, IFormFile foto)
        {
            try
            {
                string caminhoParaSalvarImagem = caminhoServidor + "\\Imagens\\";
                string novoNomeParaImagem = foto.FileName;

                if (!Directory.Exists(caminhoParaSalvarImagem))
                {
                    Directory.CreateDirectory(caminhoParaSalvarImagem);
                }

                using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
                {
                    foto.CopyToAsync(stream);
                }

                collection.foto = novoNomeParaImagem;

                Usuarios _usuarios = new Usuarios();

                _usuarios.foto = collection.foto;
                _usuarios.nome = collection.nome;
                _usuarios.sobrenome = collection.sobrenome;
                _usuarios.cidade = collection.cidade;
                _usuarios.email = collection.email;
                _usuarios.senha = collection.senha;

                db.Usuarios.Add(_usuarios);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        // GET: UsuariosController
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Usuarios.Where(a=> a.Id == id).FirstOrDefault());
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuarios collection)
        {
            try
            {
                db.Usuarios.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            db.Usuarios.Remove(db.Usuarios.Where(a=> a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        public ActionResult Perfil()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            var Id_Usuario = Int32.Parse(claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Sid).Value);

            List<CursoF> model = db.CursoF.Where(a => a.UsuarioId == Id_Usuario).Include(a => a.Curso).Include(a => a.Usuario).ToList();
            return View(model);
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        public ActionResult Configuracoes()
        {
            return View();
        }

    }
}
