using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class MetasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Metas
        public ActionResult Index()
        {
            var metas = db.Metas.Include(m => m.Indicador);
            return View(metas.ToList());
        }

        // GET: Metas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // GET: Metas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre");
            return View();
        }

        // POST: Metas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Valor_esperado,Fecha_limite,Indicador_Id")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                db.Metas.Add(meta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", meta.Id);
            return View(meta);
        }

        // GET: Metas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", meta.Id);
            return View(meta);
        }

        // POST: Metas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Valor_esperado,Fecha_limite,Indicador_Id")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Indicadors, "Id", "Nombre", meta.Id);
            return View(meta);
        }

        // GET: Metas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // POST: Metas/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meta meta = db.Metas.Find(id);
            db.Metas.Remove(meta);
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
