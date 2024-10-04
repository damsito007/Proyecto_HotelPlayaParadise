using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class PaquetesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Paquetes
        public ActionResult Index()
        {
            return View(db.Paquetes.ToList());
        }

        // GET: Paquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquetes paquetes = db.Paquetes.Find(id);
            if (paquetes == null)
            {
                return HttpNotFound();
            }
            return View(paquetes);
        }

        // GET: Paquetes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Paquete_ID,Nombre,Descripcion,Precio")] Paquetes paquetes)
        {
            if (ModelState.IsValid)
            {
                db.Paquetes.Add(paquetes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paquetes);
        }

        // GET: Paquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquetes paquetes = db.Paquetes.Find(id);
            if (paquetes == null)
            {
                return HttpNotFound();
            }
            return View(paquetes);
        }

        // POST: Paquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Paquete_ID,Nombre,Descripcion,Precio")] Paquetes paquetes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquetes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paquetes);
        }

        // GET: Paquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquetes paquetes = db.Paquetes.Find(id);
            if (paquetes == null)
            {
                return HttpNotFound();
            }
            return View(paquetes);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paquetes paquetes = db.Paquetes.Find(id);
            db.Paquetes.Remove(paquetes);
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
