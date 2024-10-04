using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Registros_Acceso_HotelController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Registros_Acceso_Hotel
        public ActionResult Index()
        {
            var registros_Acceso_Hotel = db.Registros_Acceso_Hotel.Include(r => r.Clientes);
            return View(registros_Acceso_Hotel.ToList());
        }

        // GET: Registros_Acceso_Hotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Acceso_Hotel registros_Acceso_Hotel = db.Registros_Acceso_Hotel.Find(id);
            if (registros_Acceso_Hotel == null)
            {
                return HttpNotFound();
            }
            return View(registros_Acceso_Hotel);
        }

        // GET: Registros_Acceso_Hotel/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre");
            return View();
        }

        // POST: Registros_Acceso_Hotel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Registro_Acceso_ID,Cliente_ID,Fecha_Hora_Acceso,Tipo_Acceso")] Registros_Acceso_Hotel registros_Acceso_Hotel)
        {
            if (ModelState.IsValid)
            {
                db.Registros_Acceso_Hotel.Add(registros_Acceso_Hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", registros_Acceso_Hotel.Cliente_ID);
            return View(registros_Acceso_Hotel);
        }

        // GET: Registros_Acceso_Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Acceso_Hotel registros_Acceso_Hotel = db.Registros_Acceso_Hotel.Find(id);
            if (registros_Acceso_Hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", registros_Acceso_Hotel.Cliente_ID);
            return View(registros_Acceso_Hotel);
        }

        // POST: Registros_Acceso_Hotel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Registro_Acceso_ID,Cliente_ID,Fecha_Hora_Acceso,Tipo_Acceso")] Registros_Acceso_Hotel registros_Acceso_Hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros_Acceso_Hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", registros_Acceso_Hotel.Cliente_ID);
            return View(registros_Acceso_Hotel);
        }

        // GET: Registros_Acceso_Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Acceso_Hotel registros_Acceso_Hotel = db.Registros_Acceso_Hotel.Find(id);
            if (registros_Acceso_Hotel == null)
            {
                return HttpNotFound();
            }
            return View(registros_Acceso_Hotel);
        }

        // POST: Registros_Acceso_Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registros_Acceso_Hotel registros_Acceso_Hotel = db.Registros_Acceso_Hotel.Find(id);
            db.Registros_Acceso_Hotel.Remove(registros_Acceso_Hotel);
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
