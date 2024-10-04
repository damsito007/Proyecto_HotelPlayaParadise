using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Servicios_AdicionalesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Servicios_Adicionales
        public ActionResult Index()
        {
            return View(db.Servicios_Adicionales.ToList());
        }

        // GET: Servicios_Adicionales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Adicionales servicios_Adicionales = db.Servicios_Adicionales.Find(id);
            if (servicios_Adicionales == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Adicionales);
        }

        // GET: Servicios_Adicionales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios_Adicionales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Servicio_ID,Nombre,Descripcion,Precio")] Servicios_Adicionales servicios_Adicionales)
        {
            if (ModelState.IsValid)
            {
                db.Servicios_Adicionales.Add(servicios_Adicionales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicios_Adicionales);
        }

        // GET: Servicios_Adicionales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Adicionales servicios_Adicionales = db.Servicios_Adicionales.Find(id);
            if (servicios_Adicionales == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Adicionales);
        }

        // POST: Servicios_Adicionales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Servicio_ID,Nombre,Descripcion,Precio")] Servicios_Adicionales servicios_Adicionales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios_Adicionales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicios_Adicionales);
        }

        // GET: Servicios_Adicionales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Adicionales servicios_Adicionales = db.Servicios_Adicionales.Find(id);
            if (servicios_Adicionales == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Adicionales);
        }

        // POST: Servicios_Adicionales/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios_Adicionales servicios_Adicionales = db.Servicios_Adicionales.Find(id);
            db.Servicios_Adicionales.Remove(servicios_Adicionales);
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
