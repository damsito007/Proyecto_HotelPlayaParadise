using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class PerspectivasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Perspectivas
        public ActionResult Index()
        {
            var perspectivas = db.Perspectivas.Include(p => p.Objetivoes);
            return View(perspectivas.ToList());
        }

        // GET: Perspectivas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            if (perspectiva == null)
            {
                return HttpNotFound();
            }
            return View(perspectiva);
        }

        // GET: Perspectivas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion");
            return View();
        }

        // POST: Perspectivas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perspectiva_Id,Nombre")] Perspectiva perspectiva)
        {
            if (ModelState.IsValid)
            {
                db.Perspectivas.Add(perspectiva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Objetivoes, "Perspectiva_Id", "Descripcion", perspectiva.Perspectiva_Id);
            return View(perspectiva);
        }

        // GET: Perspectivas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            if (perspectiva == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion", perspectiva.Perspectiva_Id);
            return View(perspectiva);
        }

        // POST: Perspectivas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Perspectiva_Id,Nombre")] Perspectiva perspectiva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perspectiva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion", perspectiva.Perspectiva_Id);
            return View(perspectiva);
        }

        // GET: Perspectivas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            if (perspectiva == null)
            {
                return HttpNotFound();
            }
            return View(perspectiva);
        }

        // POST: Perspectivas/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            db.Perspectivas.Remove(perspectiva);
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
