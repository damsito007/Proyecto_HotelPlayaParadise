using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class ReservacionesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Reservaciones
        public ActionResult Index()
        {
            var reservaciones = db.Reservaciones.Include(r => r.Clientes).Include(r => r.Habitaciones).Include(r => r.Intermediarios).Include(r => r.Paquetes);
            return View(reservaciones.ToList());
        }

        // GET: Reservaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre");
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion");
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre");
            ViewBag.Paquete_ID = new SelectList(db.Paquetes, "Paquete_ID", "Nombre");
            return View();
        }

        // POST: Reservaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reservacion_ID,Cliente_ID,Paquete_ID,Habitacion_ID,Intermediario_ID,Fecha_Reservacion,Metodo_Pago")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reservaciones.Add(reservaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", reservaciones.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion", reservaciones.Habitacion_ID);
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre", reservaciones.Intermediario_ID);
            ViewBag.Paquete_ID = new SelectList(db.Paquetes, "Paquete_ID", "Nombre", reservaciones.Paquete_ID);
            return View(reservaciones);
        }

        // GET: Reservaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", reservaciones.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion", reservaciones.Habitacion_ID);
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre", reservaciones.Intermediario_ID);
            ViewBag.Paquete_ID = new SelectList(db.Paquetes, "Paquete_ID", "Nombre", reservaciones.Paquete_ID);
            return View(reservaciones);
        }

        // POST: Reservaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reservacion_ID,Cliente_ID,Paquete_ID,Habitacion_ID,Intermediario_ID,Fecha_Reservacion,Metodo_Pago")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", reservaciones.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion", reservaciones.Habitacion_ID);
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre", reservaciones.Intermediario_ID);
            ViewBag.Paquete_ID = new SelectList(db.Paquetes, "Paquete_ID", "Nombre", reservaciones.Paquete_ID);
            return View(reservaciones);
        }

        // GET: Reservaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            db.Reservaciones.Remove(reservaciones);
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
