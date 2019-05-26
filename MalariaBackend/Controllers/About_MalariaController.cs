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
    public class About_MalariaController : Controller
    {
        private DBMobile_AppEntities db = new DBMobile_AppEntities();

        // GET: About_Malaria
        public ActionResult Index()
        {
            return View(db.About_Malaria.ToList());
        }

        // GET: About_Malaria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Malaria about_Malaria = db.About_Malaria.Find(id);
            if (about_Malaria == null)
            {
                return HttpNotFound();
            }
            return View(about_Malaria);
        }

        // GET: About_Malaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: About_Malaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "About_Malaria_ID,Malaria_Description")] About_Malaria about_Malaria)
        {
            if (ModelState.IsValid)
            {
                db.About_Malaria.Add(about_Malaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about_Malaria);
        }

        // GET: About_Malaria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Malaria about_Malaria = db.About_Malaria.Find(id);
            if (about_Malaria == null)
            {
                return HttpNotFound();
            }
            return View(about_Malaria);
        }

        // POST: About_Malaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "About_Malaria_ID,Malaria_Description")] About_Malaria about_Malaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about_Malaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about_Malaria);
        }

        // GET: About_Malaria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Malaria about_Malaria = db.About_Malaria.Find(id);
            if (about_Malaria == null)
            {
                return HttpNotFound();
            }
            return View(about_Malaria);
        }

        // POST: About_Malaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About_Malaria about_Malaria = db.About_Malaria.Find(id);
            db.About_Malaria.Remove(about_Malaria);
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
