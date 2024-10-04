using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Actividades_EmpleadosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Actividades_Empleados
        public ActionResult Index()
        {
            var actividades_Empleados = db.Actividades_Empleados.Include(a => a.Empleados);
            return View(actividades_Empleados.ToList());
        }

        // GET: Actividades_Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades_Empleados actividades_Empleados = db.Actividades_Empleados.Find(id);
            if (actividades_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(actividades_Empleados);
        }

        // GET: Actividades_Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre");
            return View();
        }

        // POST: Actividades_Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Actividad_ID,Empleado_ID,Fecha_Hora_Actividad,Tipo_Actividad,Rol")] Actividades_Empleados actividades_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Actividades_Empleados.Add(actividades_Empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre", actividades_Empleados.Empleado_ID);
            return View(actividades_Empleados);
        }

        // GET: Actividades_Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades_Empleados actividades_Empleados = db.Actividades_Empleados.Find(id);
            if (actividades_Empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre", actividades_Empleados.Empleado_ID);
            return View(actividades_Empleados);
        }

        // POST: Actividades_Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Actividad_ID,Empleado_ID,Fecha_Hora_Actividad,Tipo_Actividad,Rol")] Actividades_Empleados actividades_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividades_Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Empleado_ID", "Nombre", actividades_Empleados.Empleado_ID);
            return View(actividades_Empleados);
        }

        // GET: Actividades_Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades_Empleados actividades_Empleados = db.Actividades_Empleados.Find(id);
            if (actividades_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(actividades_Empleados);
        }

        // POST: Actividades_Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividades_Empleados actividades_Empleados = db.Actividades_Empleados.Find(id);
            db.Actividades_Empleados.Remove(actividades_Empleados);
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
