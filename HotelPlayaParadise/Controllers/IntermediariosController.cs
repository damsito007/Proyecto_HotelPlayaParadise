using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class IntermediariosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Intermediarios
        public ActionResult Index()
        {
            return View(db.Intermediarios.ToList());
        }

        // GET: Intermediarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intermediarios intermediarios = db.Intermediarios.Find(id);
            if (intermediarios == null)
            {
                return HttpNotFound();
            }
            return View(intermediarios);
        }

        // GET: Intermediarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Intermediarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Intermediario_ID,Nombre,Tipo_Intermediario")] Intermediarios intermediarios)
        {
            if (ModelState.IsValid)
            {
                db.Intermediarios.Add(intermediarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(intermediarios);
        }

        // GET: Intermediarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intermediarios intermediarios = db.Intermediarios.Find(id);
            if (intermediarios == null)
            {
                return HttpNotFound();
            }
            return View(intermediarios);
        }

        // POST: Intermediarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Intermediario_ID,Nombre,Tipo_Intermediario")] Intermediarios intermediarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intermediarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(intermediarios);
        }

        // GET: Intermediarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intermediarios intermediarios = db.Intermediarios.Find(id);
            if (intermediarios == null)
            {
                return HttpNotFound();
            }
            return View(intermediarios);
        }

        // POST: Intermediarios/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intermediarios intermediarios = db.Intermediarios.Find(id);
            db.Intermediarios.Remove(intermediarios);
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
