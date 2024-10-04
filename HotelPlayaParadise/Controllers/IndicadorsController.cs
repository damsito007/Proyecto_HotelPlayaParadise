using HotelPlayaParadise.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace HotelPlayaParadise.Controllers
{
    public class IndicadorsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Indicadors
        public ActionResult Index()
        {
            var indicadors = db.Indicadors.Include(i => i.Objetivo).Include(i => i.Tipo).Include(i => i.Indicador_Dato).Include(i => i.Metas);
            return View(indicadors.ToList());
        }

        // GET: Indicadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador indicador = db.Indicadors.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            return View(indicador);
        }

        // GET: Indicadors/Create
        public ActionResult Create()
        {
            ViewBag.Objetivo_Id = new SelectList(db.Objetivoes, "Id", "Descripcion");
            ViewBag.Tipo_Id = new SelectList(db.Tipoes, "Tipo_Id", "Nombre");
            ViewBag.Id = new SelectList(db.Indicador_Dato, "Id", "Valor");
            ViewBag.Id = new SelectList(db.Metas, "Id", "Descripcion");
            return View();
        }

        // POST: Indicadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Frecuencia_Medida,Unidad_Medida,Objetivo_Id,Tipo_Id")] Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Indicadors.Add(indicador);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                            Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }

            ViewBag.Objetivo_Id = new SelectList(db.Objetivoes, "Id", "Descripcion", indicador.Objetivo_Id);
            ViewBag.Tipo_Id = new SelectList(db.Tipoes, "Tipo_Id", "Nombre", indicador.Tipo_Id);
            ViewBag.Id = new SelectList(db.Indicador_Dato, "Id", "Valor", indicador.Id);
            ViewBag.Id = new SelectList(db.Metas, "Id", "Descripcion", indicador.Id);

            return View(indicador);
        }

        // GET: Indicadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador indicador = db.Indicadors.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            ViewBag.Objetivo_Id = new SelectList(db.Objetivoes, "Id", "Descripcion", indicador.Objetivo_Id);
            ViewBag.Tipo_Id = new SelectList(db.Tipoes, "Tipo_Id", "Nombre", indicador.Tipo_Id);
            ViewBag.Id = new SelectList(db.Indicador_Dato, "Id", "Valor", indicador.Id);
            ViewBag.Id = new SelectList(db.Metas, "Id", "Descripcion", indicador.Id);
            return View(indicador);
        }

        // POST: Indicadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Frecuencia_Medida,Unidad_Medida,Objetivo_Id,Tipo_Id")] Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Objetivo_Id = new SelectList(db.Objetivoes, "Id", "Descripcion", indicador.Objetivo_Id);
            ViewBag.Tipo_Id = new SelectList(db.Tipoes, "Tipo_Id", "Nombre", indicador.Tipo_Id);
            ViewBag.Id = new SelectList(db.Indicador_Dato, "Id", "Valor", indicador.Id);
            ViewBag.Id = new SelectList(db.Metas, "Id", "Descripcion", indicador.Id);
            return View(indicador);
        }

        // GET: Indicadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador indicador = db.Indicadors.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            return View(indicador);
        }

        // POST: Indicadors/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indicador indicador = db.Indicadors.Find(id);
            db.Indicadors.Remove(indicador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
