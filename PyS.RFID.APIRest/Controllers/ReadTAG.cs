using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PyS.RFID.APIRest.Controllers
{
    public class ReadTAG : Controller
    {
        // GET: ReadTAG
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReadTAG/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReadTAG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReadTAG/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadTAG/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReadTAG/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadTAG/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReadTAG/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
