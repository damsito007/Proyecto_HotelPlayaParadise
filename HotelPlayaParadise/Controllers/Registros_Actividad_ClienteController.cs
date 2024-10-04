using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Registros_Actividad_ClienteController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Registros_Actividad_Cliente
        public ActionResult Index()
        {
            var registros_Actividad_Cliente = db.Registros_Actividad_Cliente.Include(r => r.Clientes);
            return View(registros_Actividad_Cliente.ToList());
        }

        // GET: Registros_Actividad_Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Actividad_Cliente registros_Actividad_Cliente = db.Registros_Actividad_Cliente.Find(id);
            if (registros_Actividad_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(registros_Actividad_Cliente);
        }

        // GET: Registros_Actividad_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre");
            return View();
        }

        // POST: Registros_Actividad_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Registro_ID,Cliente_ID,Fecha_Hora_Actividad,Tipo_Actividad")] Registros_Actividad_Cliente registros_Actividad_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Registros_Actividad_Cliente.Add(registros_Actividad_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", registros_Actividad_Cliente.Cliente_ID);
            return View(registros_Actividad_Cliente);
        }

        // GET: Registros_Actividad_Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Actividad_Cliente registros_Actividad_Cliente = db.Registros_Actividad_Cliente.Find(id);
            if (registros_Actividad_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", registros_Actividad_Cliente.Cliente_ID);
            return View(registros_Actividad_Cliente);
        }

        // POST: Registros_Actividad_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Registro_ID,Cliente_ID,Fecha_Hora_Actividad,Tipo_Actividad")] Registros_Actividad_Cliente registros_Actividad_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros_Actividad_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", registros_Actividad_Cliente.Cliente_ID);
            return View(registros_Actividad_Cliente);
        }

        // GET: Registros_Actividad_Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Actividad_Cliente registros_Actividad_Cliente = db.Registros_Actividad_Cliente.Find(id);
            if (registros_Actividad_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(registros_Actividad_Cliente);
        }

        // POST: Registros_Actividad_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registros_Actividad_Cliente registros_Actividad_Cliente = db.Registros_Actividad_Cliente.Find(id);
            db.Registros_Actividad_Cliente.Remove(registros_Actividad_Cliente);
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
