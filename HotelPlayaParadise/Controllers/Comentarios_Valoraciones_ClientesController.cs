using HotelPlayaParadise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class Comentarios_Valoraciones_ClientesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Comentarios_Valoraciones_Clientes
        public ActionResult Index()
        {
            var comentarios_Valoraciones_Clientes = db.Comentarios_Valoraciones_Clientes.Include(c => c.Clientes);
            return View(comentarios_Valoraciones_Clientes.ToList());
        }

        // GET: Comentarios_Valoraciones_Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios_Valoraciones_Clientes comentarios_Valoraciones_Clientes = db.Comentarios_Valoraciones_Clientes.Find(id);
            if (comentarios_Valoraciones_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(comentarios_Valoraciones_Clientes);
        }

        // GET: Comentarios_Valoraciones_Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre");
            return View();
        }

        // POST: Comentarios_Valoraciones_Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comentario_ID,Cliente_ID,Comentario,Valoracion")] Comentarios_Valoraciones_Clientes comentarios_Valoraciones_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios_Valoraciones_Clientes.Add(comentarios_Valoraciones_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", comentarios_Valoraciones_Clientes.Cliente_ID);
            return View(comentarios_Valoraciones_Clientes);
        }

        // GET: Comentarios_Valoraciones_Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios_Valoraciones_Clientes comentarios_Valoraciones_Clientes = db.Comentarios_Valoraciones_Clientes.Find(id);
            if (comentarios_Valoraciones_Clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", comentarios_Valoraciones_Clientes.Cliente_ID);
            return View(comentarios_Valoraciones_Clientes);
        }

        // POST: Comentarios_Valoraciones_Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Comentario_ID,Cliente_ID,Comentario,Valoracion")] Comentarios_Valoraciones_Clientes comentarios_Valoraciones_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarios_Valoraciones_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Cliente_ID", "Nombre", comentarios_Valoraciones_Clientes.Cliente_ID);
            return View(comentarios_Valoraciones_Clientes);
        }

        // GET: Comentarios_Valoraciones_Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios_Valoraciones_Clientes comentarios_Valoraciones_Clientes = db.Comentarios_Valoraciones_Clientes.Find(id);
            if (comentarios_Valoraciones_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(comentarios_Valoraciones_Clientes);
        }

        // POST: Comentarios_Valoraciones_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentarios_Valoraciones_Clientes comentarios_Valoraciones_Clientes = db.Comentarios_Valoraciones_Clientes.Find(id);
            db.Comentarios_Valoraciones_Clientes.Remove(comentarios_Valoraciones_Clientes);
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
