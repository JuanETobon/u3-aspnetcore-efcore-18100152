using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using u3_aspnetcore_efcore_18100152.Models;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class ZapateriaController : Controller
    {
        private readonly ZapateriaContext db;

        public ZapateriaController(ZapateriaContext context)
        {
            db = context;
        }

        // GET: ZapateriaController
        public ActionResult ListadoRegistros()
        {
            var Zapateria = db.Marcas.Include(m => m.IdModeloNavigation).ToList();

            return View(Zapateria);
        }

        public ActionResult CargarRegistros()
        {

            db.Add(new Marca { NombreDeMarca = "Agregado1", IdModelo = 1 });
            db.Add(new Marca { NombreDeMarca = "Agregado2", IdModelo = 2 });
            db.Add(new Marca { NombreDeMarca = "Agregado3", IdModelo = 3 });
            db.Add(new Marca { NombreDeMarca = "Agregado4", IdModelo = 1 });
            db.Add(new Marca { NombreDeMarca = "Agregado5", IdModelo = 2 });
            db.SaveChanges();

            return RedirectToAction("ListadoRegistros");

        }

        public ActionResult AgregarRegistro()
        {

            ViewBag.Modelos = new SelectList(db.Modelos, "Id", "ModeloDeZapato");

            return View();
        }
        [HttpPost]
        public ActionResult AgregarRegistro(Marca m)
        {
            if (ModelState.IsValid)
            {
                // insertar en la BD
                db.Add(m);
                db.SaveChanges();

                return View("RegistroAgregado", m);
            }
            ViewBag.Modelos = new SelectList(db.Modelos, "Id", "ModeloDeZapato");

            return View(m);
        }

        public ActionResult EditarRegistro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = db.Marcas.Find(id);

            if (marca == null)
            {
                return NotFound();
            }

            ViewBag.Modelos = new SelectList(db.Modelos, "Id", "ModeloDeZapato"); ;

            return View(marca);

        }
        [HttpPost]
        public ActionResult EditarRegistro(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(marca);
                db.SaveChanges();

                return RedirectToAction("ListadoRegistros");
            }

            ViewBag.Modelos = new SelectList(db.Modelos, "Id", "ModeloDeZapato");
            return View(marca);

        }

        public ActionResult EliminarRegistro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = db.Marcas.Find(id);

            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        public IActionResult ConfirmacionEliminar(int id)
        {
            var marca = db.Marcas.Find(id);

            db.Remove(marca);
            db.SaveChanges();

            return RedirectToAction("ListadoRegistros");

        }
    }
}

