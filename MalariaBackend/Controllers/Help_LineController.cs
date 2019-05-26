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
    public class Help_LineController : Controller
    {
        private DBMobile_AppEntities db = new DBMobile_AppEntities();

        // GET: Help_Line
        public ActionResult Index()
        {
            var help_Line = db.Help_Line.Include(h => h.About_Malaria);
            return View(help_Line.ToList());
        }

        // GET: Help_Line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help_Line help_Line = db.Help_Line.Find(id);
            if (help_Line == null)
            {
                return HttpNotFound();
            }
            return View(help_Line);
        }

        // GET: Help_Line/Create
        public ActionResult Create()
        {
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description");
            return View();
        }

        // POST: Help_Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Help_Line_ID,About_Malaria_ID,Help_Line_Contact,Help_Line_Practioner")] Help_Line help_Line)
        {
            if (ModelState.IsValid)
            {
                db.Help_Line.Add(help_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", help_Line.About_Malaria_ID);
            return View(help_Line);
        }

        // GET: Help_Line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help_Line help_Line = db.Help_Line.Find(id);
            if (help_Line == null)
            {
                return HttpNotFound();
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", help_Line.About_Malaria_ID);
            return View(help_Line);
        }

        // POST: Help_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Help_Line_ID,About_Malaria_ID,Help_Line_Contact,Help_Line_Practioner")] Help_Line help_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(help_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", help_Line.About_Malaria_ID);
            return View(help_Line);
        }

        // GET: Help_Line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help_Line help_Line = db.Help_Line.Find(id);
            if (help_Line == null)
            {
                return HttpNotFound();
            }
            return View(help_Line);
        }

        // POST: Help_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Help_Line help_Line = db.Help_Line.Find(id);
            db.Help_Line.Remove(help_Line);
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
