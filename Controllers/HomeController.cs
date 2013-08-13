using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumerResource.Models;

namespace HumerResource.Controllers
{
    public class HomeController : Controller
    {
        private HumerResourceEntities db = new HumerResourceEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Agents agents)
        {
            if (ModelState.IsValid)
            {
                db.Agents.Add(agents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agents);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agents agents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agents);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agents agents = db.Agents.Find(id);
            db.Agents.Remove(agents);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}