using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class ObjetivosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Objetivos
        public ActionResult Index()
        {
            var objetivoes = db.Objetivoes.Include(o => o.CMI).Include(o => o.Indicadors).Include(o => o.Perspectiva);
            return View(objetivoes.ToList());
        }

        // GET: Objetivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetivo objetivo = db.Objetivoes.Find(id);
            if (objetivo == null)
            {
                return HttpNotFound();
            }
            return View(objetivo);
        }

        // GET: Objetivos/Create
        public ActionResult Create()
        {
            ViewBag.CMI_Id = new SelectList(db.CMIs, "Id", "Nombre");
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre");
            ViewBag.Perspectiva_Id = new SelectList(db.Perspectivas, "Perspectiva_Id", "Nombre");
            return View();
        }

        // POST: Objetivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Metrica,Ponderacion, CMI_Id, Perspectiva_Id")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                db.Objetivoes.Add(objetivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CMI_Id = new SelectList(db.CMIs, "Id", "Nombre", objetivo.Id);
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", objetivo.Id);
            ViewBag.Perspectiva_Id = new SelectList(db.Perspectivas, "Perspectiva_Id", "Nombre", objetivo.Perspectiva_Id);
            return View(objetivo);
        }

        // GET: Objetivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetivo objetivo = db.Objetivoes.Find(id);
            if (objetivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CMI_Id = new SelectList(db.CMIs, "Id", "Nombre", objetivo.Id);
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", objetivo.Id);
            ViewBag.Perspectiva_Id = new SelectList(db.Perspectivas, "Perspectiva_Id", "Nombre", objetivo.Perspectiva_Id);
            return View(objetivo);
        }

        // POST: Objetivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Metrica,Ponderacion, CMI_Id, Perspectiva_Id")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CMI_Id = new SelectList(db.CMIs, "Id", "Nombre", objetivo.Id);
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", objetivo.Id);
            ViewBag.Perspectiva_Id = new SelectList(db.Perspectivas, "Perspectiva_Id", "Nombre", objetivo.Perspectiva_Id);
            return View(objetivo);
        }

        // GET: Objetivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetivo objetivo = db.Objetivoes.Find(id);
            if (objetivo == null)
            {
                return HttpNotFound();
            }
            return View(objetivo);
        }

        // POST: Objetivos/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objetivo objetivo = db.Objetivoes.Find(id);
            db.Objetivoes.Remove(objetivo);
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
