using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class CMIsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: CMIs
        public ActionResult Index()
        {
            var cMIs = db.CMIs.Include(c => c.Objetivoes);
            return View(cMIs.ToList());
        }

        // GET: CMIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMI cMI = db.CMIs.Find(id);
            if (cMI == null)
            {
                return HttpNotFound();
            }
            return View(cMI);
        }

        // GET: CMIs/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion");
            return View();
        }

        // POST: CMIs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Periodo")] CMI cMI)
        {
            if (ModelState.IsValid)
            {
                db.CMIs.Add(cMI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion", cMI.Id);
            return View(cMI);
        }

        // GET: CMIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMI cMI = db.CMIs.Find(id);
            if (cMI == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion", cMI.Id);
            return View(cMI);
        }

        // POST: CMIs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Periodo")] CMI cMI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Objetivoes, "Id", "Descripcion", cMI.Id);
            return View(cMI);
        }

        // GET: CMIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMI cMI = db.CMIs.Find(id);
            if (cMI == null)
            {
                return HttpNotFound();
            }
            return View(cMI);
        }

        // POST: CMIs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMI cMI = db.CMIs.Find(id);
            db.CMIs.Remove(cMI);
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
