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

namespace AquiOuAcola.Controllers
{
    public class CursosController : Controller
    {
        private readonly Contexto db;
        private string caminhoServidor;

        public CursosController(Contexto contexto, IWebHostEnvironment sistema)
        {
            db = contexto;
            caminhoServidor = sistema.WebRootPath;
        }

        // GET: CursosController
        public ActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(db.Cursos.ToList());
            }
            else
            {
                return View(db.Cursos.Where(a => a.nome.Contains(query) || a.gratuito.Contains(query) || a.nivel.Contains(query)));
            }
        }

        // GET: CursosController/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Cursos.Find(id));
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]

        // GET: CursosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Curso collection, IFormFile foto)
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
                    await foto.CopyToAsync(stream);
                }

                collection.foto = novoNomeParaImagem;

                Curso _cursos = new Curso();

                _cursos.Id_Usuario = collection.Id_Usuario;
                _cursos.foto = collection.foto;
                _cursos.nome = collection.nome;
                _cursos.disponibilidade = collection.disponibilidade;
                _cursos.gratuito = collection.gratuito;
                _cursos.link = collection.link;
                _cursos.descricao = collection.descricao;
                _cursos.nivel = collection.nivel;

                db.Cursos.Add(_cursos);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CursosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
