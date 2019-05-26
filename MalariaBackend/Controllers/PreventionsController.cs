using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MalariaBackend.Models;

namespace MalariaBackend.Controllers
{
    public class PreventionsController : Controller
    {
        private DBMobile_AppEntities db = new DBMobile_AppEntities();

        // GET: Preventions
        public ActionResult Index()
        {
            var preventions = db.Preventions.Include(p => p.About_Malaria);
            return View(preventions.ToList());
        }

        // GET: Preventions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevention prevention = db.Preventions.Find(id);
            if (prevention == null)
            {
                return HttpNotFound();
            }
            return View(prevention);
        }

        // GET: Preventions/Create
        public ActionResult Create()
        {
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description");
            return View();
        }

        // POST: Preventions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prevention_ID,About_Malaria_ID,Prevention_Method")] Prevention prevention)
        {
            if (ModelState.IsValid)
            {
                db.Preventions.Add(prevention);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", prevention.About_Malaria_ID);
            return View(prevention);
        }

        // GET: Preventions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevention prevention = db.Preventions.Find(id);
            if (prevention == null)
            {
                return HttpNotFound();
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", prevention.About_Malaria_ID);
            return View(prevention);
        }

        // POST: Preventions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prevention_ID,About_Malaria_ID,Prevention_Method")] Prevention prevention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prevention).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", prevention.About_Malaria_ID);
            return View(prevention);
        }

        // GET: Preventions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prevention prevention = db.Preventions.Find(id);
            if (prevention == null)
            {
                return HttpNotFound();
            }
            return View(prevention);
        }

        // POST: Preventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prevention prevention = db.Preventions.Find(id);
            db.Preventions.Remove(prevention);
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
