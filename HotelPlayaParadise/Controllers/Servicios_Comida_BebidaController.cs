using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Servicios_Comida_BebidaController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Servicios_Comida_Bebida
        public ActionResult Index()
        {
            var servicios_Comida_Bebida = db.Servicios_Comida_Bebida.Include(s => s.Clientes).Include(s => s.Productos);
            return View(servicios_Comida_Bebida.ToList());
        }

        // GET: Servicios_Comida_Bebida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Comida_Bebida servicios_Comida_Bebida = db.Servicios_Comida_Bebida.Find(id);
            if (servicios_Comida_Bebida == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Comida_Bebida);
        }

        // GET: Servicios_Comida_Bebida/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre");
            ViewBag.Producto_ID = new SelectList(db.Productos, "Producto_ID", "Producto_ID");
            return View();
        }

        // POST: Servicios_Comida_Bebida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Servicio_Comida_Bebida_ID,Cliente_ID,Fecha_Hora,Producto_ID,Cantidad")] Servicios_Comida_Bebida servicios_Comida_Bebida)
        {
            if (ModelState.IsValid)
            {
                db.Servicios_Comida_Bebida.Add(servicios_Comida_Bebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", servicios_Comida_Bebida.Cliente_ID);
            ViewBag.Producto_ID = new SelectList(db.Productos, "Producto_ID", "Producto_ID", servicios_Comida_Bebida.Producto_ID);
            return View(servicios_Comida_Bebida);
        }

        // GET: Servicios_Comida_Bebida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Comida_Bebida servicios_Comida_Bebida = db.Servicios_Comida_Bebida.Find(id);
            if (servicios_Comida_Bebida == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", servicios_Comida_Bebida.Cliente_ID);
            ViewBag.Producto_ID = new SelectList(db.Productos, "Producto_ID", "Producto_ID", servicios_Comida_Bebida.Producto_ID);
            return View(servicios_Comida_Bebida);
        }

        // POST: Servicios_Comida_Bebida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Servicio_Comida_Bebida_ID,Cliente_ID,Fecha_Hora,Producto_ID,Cantidad")] Servicios_Comida_Bebida servicios_Comida_Bebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios_Comida_Bebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", servicios_Comida_Bebida.Cliente_ID);
            ViewBag.Producto_ID = new SelectList(db.Productos, "Producto_ID", "Producto_ID", servicios_Comida_Bebida.Producto_ID);
            return View(servicios_Comida_Bebida);
        }

        // GET: Servicios_Comida_Bebida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Comida_Bebida servicios_Comida_Bebida = db.Servicios_Comida_Bebida.Find(id);
            if (servicios_Comida_Bebida == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Comida_Bebida);
        }

        // POST: Servicios_Comida_Bebida/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios_Comida_Bebida servicios_Comida_Bebida = db.Servicios_Comida_Bebida.Find(id);
            db.Servicios_Comida_Bebida.Remove(servicios_Comida_Bebida);
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
