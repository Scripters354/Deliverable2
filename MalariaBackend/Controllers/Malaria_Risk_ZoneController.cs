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
    public class Malaria_Risk_ZoneController : Controller
    {
        private DBMobile_AppEntities db = new DBMobile_AppEntities();

        // GET: Malaria_Risk_Zone
        public ActionResult Index()
        {
            var malaria_Risk_Zone = db.Malaria_Risk_Zone.Include(m => m.About_Malaria);
            return View(malaria_Risk_Zone.ToList());
        }

        // GET: Malaria_Risk_Zone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Malaria_Risk_Zone malaria_Risk_Zone = db.Malaria_Risk_Zone.Find(id);
            if (malaria_Risk_Zone == null)
            {
                return HttpNotFound();
            }
            return View(malaria_Risk_Zone);
        }

        // GET: Malaria_Risk_Zone/Create
        public ActionResult Create()
        {
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description");
            return View();
        }

        // POST: Malaria_Risk_Zone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Malaria_Risk_Zone_ID,About_Malaria_ID,Risk_Zone_Location,Risk_Zone,Severity")] Malaria_Risk_Zone malaria_Risk_Zone)
        {
            if (ModelState.IsValid)
            {
                db.Malaria_Risk_Zone.Add(malaria_Risk_Zone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", malaria_Risk_Zone.About_Malaria_ID);
            return View(malaria_Risk_Zone);
        }

        // GET: Malaria_Risk_Zone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Malaria_Risk_Zone malaria_Risk_Zone = db.Malaria_Risk_Zone.Find(id);
            if (malaria_Risk_Zone == null)
            {
                return HttpNotFound();
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", malaria_Risk_Zone.About_Malaria_ID);
            return View(malaria_Risk_Zone);
        }

        // POST: Malaria_Risk_Zone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Malaria_Risk_Zone_ID,About_Malaria_ID,Risk_Zone_Location,Risk_Zone,Severity")] Malaria_Risk_Zone malaria_Risk_Zone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(malaria_Risk_Zone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", malaria_Risk_Zone.About_Malaria_ID);
            return View(malaria_Risk_Zone);
        }

        // GET: Malaria_Risk_Zone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Malaria_Risk_Zone malaria_Risk_Zone = db.Malaria_Risk_Zone.Find(id);
            if (malaria_Risk_Zone == null)
            {
                return HttpNotFound();
            }
            return View(malaria_Risk_Zone);
        }

        // POST: Malaria_Risk_Zone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Malaria_Risk_Zone malaria_Risk_Zone = db.Malaria_Risk_Zone.Find(id);
            db.Malaria_Risk_Zone.Remove(malaria_Risk_Zone);
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
