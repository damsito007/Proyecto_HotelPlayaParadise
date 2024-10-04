using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Registros_Actividad_IntermediarioController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Registros_Actividad_Intermediario
        public ActionResult Index()
        {
            var registros_Actividad_Intermediario = db.Registros_Actividad_Intermediario.Include(r => r.Empleados).Include(r => r.Intermediarios);
            return View(registros_Actividad_Intermediario.ToList());
        }

        // GET: Registros_Actividad_Intermediario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Actividad_Intermediario registros_Actividad_Intermediario = db.Registros_Actividad_Intermediario.Find(id);
            if (registros_Actividad_Intermediario == null)
            {
                return HttpNotFound();
            }
            return View(registros_Actividad_Intermediario);
        }

        // GET: Registros_Actividad_Intermediario/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre");
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre");
            return View();
        }

        // POST: Registros_Actividad_Intermediario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Registro_Intermediario_ID,Intermediario_ID,Empleado_ID,Rol,Fecha_Hora_Actividad,Tipo_Actividad")] Registros_Actividad_Intermediario registros_Actividad_Intermediario)
        {
            if (ModelState.IsValid)
            {
                db.Registros_Actividad_Intermediario.Add(registros_Actividad_Intermediario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre", registros_Actividad_Intermediario.Empleado_ID);
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre", registros_Actividad_Intermediario.Intermediario_ID);
            return View(registros_Actividad_Intermediario);
        }

        // GET: Registros_Actividad_Intermediario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Actividad_Intermediario registros_Actividad_Intermediario = db.Registros_Actividad_Intermediario.Find(id);
            if (registros_Actividad_Intermediario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre", registros_Actividad_Intermediario.Empleado_ID);
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre", registros_Actividad_Intermediario.Intermediario_ID);
            return View(registros_Actividad_Intermediario);
        }

        // POST: Registros_Actividad_Intermediario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Registro_Intermediario_ID,Intermediario_ID,Empleado_ID,Rol,Fecha_Hora_Actividad,Tipo_Actividad")] Registros_Actividad_Intermediario registros_Actividad_Intermediario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros_Actividad_Intermediario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre", registros_Actividad_Intermediario.Empleado_ID);
            ViewBag.Intermediario_ID = new SelectList(db.Intermediarios, "Intermediario_ID", "Nombre", registros_Actividad_Intermediario.Intermediario_ID);
            return View(registros_Actividad_Intermediario);
        }

        // GET: Registros_Actividad_Intermediario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros_Actividad_Intermediario registros_Actividad_Intermediario = db.Registros_Actividad_Intermediario.Find(id);
            if (registros_Actividad_Intermediario == null)
            {
                return HttpNotFound();
            }
            return View(registros_Actividad_Intermediario);
        }

        // POST: Registros_Actividad_Intermediario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registros_Actividad_Intermediario registros_Actividad_Intermediario = db.Registros_Actividad_Intermediario.Find(id);
            db.Registros_Actividad_Intermediario.Remove(registros_Actividad_Intermediario);
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
