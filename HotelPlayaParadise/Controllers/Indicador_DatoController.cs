using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Indicador_DatoController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Indicador_Dato
        public ActionResult Index()
        {
            var indicador_Dato = db.Indicador_Dato.Include(i => i.Indicador);
            return View(indicador_Dato.ToList());
        }

        // GET: Indicador_Dato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador_Dato indicador_Dato = db.Indicador_Dato.Find(id);
            if (indicador_Dato == null)
            {
                return HttpNotFound();
            }
            return View(indicador_Dato);
        }

        // GET: Indicador_Dato/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre");
            return View();
        }

        // POST: Indicador_Dato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,Fecha, Indicador_Id")] Indicador_Dato indicador_Dato)
        {
            if (ModelState.IsValid)
            {
                db.Indicador_Dato.Add(indicador_Dato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", indicador_Dato.Id);
            return View(indicador_Dato);
        }

        // GET: Indicador_Dato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador_Dato indicador_Dato = db.Indicador_Dato.Find(id);
            if (indicador_Dato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", indicador_Dato.Id);
            return View(indicador_Dato);
        }

        // POST: Indicador_Dato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Fecha, Indicador_Id")] Indicador_Dato indicador_Dato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador_Dato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", indicador_Dato.Id);
            return View(indicador_Dato);
        }

        // GET: Indicador_Dato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador_Dato indicador_Dato = db.Indicador_Dato.Find(id);
            if (indicador_Dato == null)
            {
                return HttpNotFound();
            }
            return View(indicador_Dato);
        }

        // POST: Indicador_Dato/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indicador_Dato indicador_Dato = db.Indicador_Dato.Find(id);
            db.Indicador_Dato.Remove(indicador_Dato);
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
