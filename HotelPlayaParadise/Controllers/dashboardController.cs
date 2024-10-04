using System.Web.Mvc;

namespace HotelPlayaParadise.Controllers
{
    public class dashboardController : Controller
    {
        // GET: dashboard
        public ActionResult Index()
        {
            return View();
        }

        // GET: dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
