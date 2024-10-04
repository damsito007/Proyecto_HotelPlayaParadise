using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Check_in_OutController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Check_in_Out
        public ActionResult Index()
        {
            var check_in_Out = db.Check_in_Out.Include(c => c.Clientes).Include(c => c.Habitaciones);
            return View(check_in_Out.ToList());
        }

        // GET: Check_in_Out/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check_in_Out check_in_Out = db.Check_in_Out.Find(id);
            if (check_in_Out == null)
            {
                return HttpNotFound();
            }
            return View(check_in_Out);
        }

        // GET: Check_in_Out/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre");
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion");
            return View();
        }

        // POST: Check_in_Out/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Check_in_Out_ID,Cliente_ID,Habitacion_ID,Fecha_Check_in,Fecha_Check_out")] Check_in_Out check_in_Out)
        {
            if (ModelState.IsValid)
            {
                db.Check_in_Out.Add(check_in_Out);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", check_in_Out.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion", check_in_Out.Habitacion_ID);
            return View(check_in_Out);
        }

        // GET: Check_in_Out/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check_in_Out check_in_Out = db.Check_in_Out.Find(id);
            if (check_in_Out == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", check_in_Out.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion", check_in_Out.Habitacion_ID);
            return View(check_in_Out);
        }

        // POST: Check_in_Out/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Check_in_Out_ID,Cliente_ID,Habitacion_ID,Fecha_Check_in,Fecha_Check_out")] Check_in_Out check_in_Out)
        {
            if (ModelState.IsValid)
            {
                db.Entry(check_in_Out).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", check_in_Out.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "Habitacion_ID", "Tipo_Habitacion", check_in_Out.Habitacion_ID);
            return View(check_in_Out);
        }

        // GET: Check_in_Out/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check_in_Out check_in_Out = db.Check_in_Out.Find(id);
            if (check_in_Out == null)
            {
                return HttpNotFound();
            }
            return View(check_in_Out);
        }

        // POST: Check_in_Out/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Check_in_Out check_in_Out = db.Check_in_Out.Find(id);
            db.Check_in_Out.Remove(check_in_Out);
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
