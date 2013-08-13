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
    public class AddressController : Controller
    {
        private HumerResourceEntities db = new HumerResourceEntities();

        //
        // GET: /Address/

        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.Agents);
            return View(addresses.ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            ViewBag.AgentsID = new SelectList(db.Agents, "AgentsID", "FirstName");
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(addresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentsID = new SelectList(db.Agents, "AgentsID", "FirstName", addresses.AgentsID);
            return View(addresses);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentsID = new SelectList(db.Agents, "AgentsID", "FirstName", addresses.AgentsID);
            return View(addresses);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Addresses addresses)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(addresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentsID = new SelectList(db.Agents, "AgentsID", "FirstName", addresses.AgentsID);
            return View(addresses);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Addresses addresses = db.Addresses.Find(id);
            db.Addresses.Remove(addresses);
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