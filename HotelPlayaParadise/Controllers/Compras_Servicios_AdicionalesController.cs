using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Compras_Servicios_AdicionalesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Compras_Servicios_Adicionales
        public ActionResult Index()
        {
            var compras_Servicios_Adicionales = db.Compras_Servicios_Adicionales.Include(c => c.Reservaciones).Include(c => c.Servicios_Adicionales);
            return View(compras_Servicios_Adicionales.ToList());
        }

        // GET: Compras_Servicios_Adicionales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras_Servicios_Adicionales compras_Servicios_Adicionales = db.Compras_Servicios_Adicionales.Find(id);
            if (compras_Servicios_Adicionales == null)
            {
                return HttpNotFound();
            }
            return View(compras_Servicios_Adicionales);
        }

        // GET: Compras_Servicios_Adicionales/Create
        public ActionResult Create()
        {
            ViewBag.Reservacion_ID = new SelectList(db.Reservaciones, "Reservacion_ID", "Metodo_Pago");
            ViewBag.Servicio_ID = new SelectList(db.Servicios_Adicionales, "Servicio_ID", "Nombre");
            return View();
        }

        // POST: Compras_Servicios_Adicionales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Compra_Servicio_ID,Reservacion_ID,Servicio_ID,Fecha_Hora,Cantidad")] Compras_Servicios_Adicionales compras_Servicios_Adicionales)
        {
            if (ModelState.IsValid)
            {
                db.Compras_Servicios_Adicionales.Add(compras_Servicios_Adicionales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Reservacion_ID = new SelectList(db.Reservaciones, "Reservacion_ID", "Metodo_Pago", compras_Servicios_Adicionales.Reservacion_ID);
            ViewBag.Servicio_ID = new SelectList(db.Servicios_Adicionales, "Servicio_ID", "Nombre", compras_Servicios_Adicionales.Servicio_ID);
            return View(compras_Servicios_Adicionales);
        }

        // GET: Compras_Servicios_Adicionales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras_Servicios_Adicionales compras_Servicios_Adicionales = db.Compras_Servicios_Adicionales.Find(id);
            if (compras_Servicios_Adicionales == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reservacion_ID = new SelectList(db.Reservaciones, "Reservacion_ID", "Metodo_Pago", compras_Servicios_Adicionales.Reservacion_ID);
            ViewBag.Servicio_ID = new SelectList(db.Servicios_Adicionales, "Servicio_ID", "Nombre", compras_Servicios_Adicionales.Servicio_ID);
            return View(compras_Servicios_Adicionales);
        }

        // POST: Compras_Servicios_Adicionales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Compra_Servicio_ID,Reservacion_ID,Servicio_ID,Fecha_Hora,Cantidad")] Compras_Servicios_Adicionales compras_Servicios_Adicionales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras_Servicios_Adicionales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Reservacion_ID = new SelectList(db.Reservaciones, "Reservacion_ID", "Metodo_Pago", compras_Servicios_Adicionales.Reservacion_ID);
            ViewBag.Servicio_ID = new SelectList(db.Servicios_Adicionales, "Servicio_ID", "Nombre", compras_Servicios_Adicionales.Servicio_ID);
            return View(compras_Servicios_Adicionales);
        }

        // GET: Compras_Servicios_Adicionales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras_Servicios_Adicionales compras_Servicios_Adicionales = db.Compras_Servicios_Adicionales.Find(id);
            if (compras_Servicios_Adicionales == null)
            {
                return HttpNotFound();
            }
            return View(compras_Servicios_Adicionales);
        }

        // POST: Compras_Servicios_Adicionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compras_Servicios_Adicionales compras_Servicios_Adicionales = db.Compras_Servicios_Adicionales.Find(id);
            db.Compras_Servicios_Adicionales.Remove(compras_Servicios_Adicionales);
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
