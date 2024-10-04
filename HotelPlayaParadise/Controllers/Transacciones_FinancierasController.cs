using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Transacciones_FinancierasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Transacciones_Financieras
        public ActionResult Index()
        {
            return View(db.Transacciones_Financieras.ToList());
        }

        // GET: Transacciones_Financieras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones_Financieras transacciones_Financieras = db.Transacciones_Financieras.Find(id);
            if (transacciones_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(transacciones_Financieras);
        }

        // GET: Transacciones_Financieras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacciones_Financieras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Transaccion_ID,Tipo_Transaccion,Monto,Fecha_Hora,Metodo_Pago")] Transacciones_Financieras transacciones_Financieras)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones_Financieras.Add(transacciones_Financieras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transacciones_Financieras);
        }

        // GET: Transacciones_Financieras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones_Financieras transacciones_Financieras = db.Transacciones_Financieras.Find(id);
            if (transacciones_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(transacciones_Financieras);
        }

        // POST: Transacciones_Financieras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Transaccion_ID,Tipo_Transaccion,Monto,Fecha_Hora,Metodo_Pago")] Transacciones_Financieras transacciones_Financieras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones_Financieras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transacciones_Financieras);
        }

        // GET: Transacciones_Financieras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones_Financieras transacciones_Financieras = db.Transacciones_Financieras.Find(id);
            if (transacciones_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(transacciones_Financieras);
        }

        // POST: Transacciones_Financieras/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacciones_Financieras transacciones_Financieras = db.Transacciones_Financieras.Find(id);
            db.Transacciones_Financieras.Remove(transacciones_Financieras);
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
