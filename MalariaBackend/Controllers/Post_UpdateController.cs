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
    public class Post_UpdateController : Controller
    {
        private DBMobile_AppEntities db = new DBMobile_AppEntities();

        // GET: Post_Update
        public ActionResult Index()
        {
            var post_Update = db.Post_Update.Include(p => p.About_Malaria);
            return View(post_Update.ToList());
        }

        // GET: Post_Update/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post_Update post_Update = db.Post_Update.Find(id);
            if (post_Update == null)
            {
                return HttpNotFound();
            }
            return View(post_Update);
        }

        // GET: Post_Update/Create
        public ActionResult Create()
        {
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description");
            return View();
        }

        // POST: Post_Update/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Post_Update_ID,About_Malaria_ID,Post_Description")] Post_Update post_Update)
        {
            if (ModelState.IsValid)
            {
                db.Post_Update.Add(post_Update);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", post_Update.About_Malaria_ID);
            return View(post_Update);
        }

        // GET: Post_Update/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post_Update post_Update = db.Post_Update.Find(id);
            if (post_Update == null)
            {
                return HttpNotFound();
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", post_Update.About_Malaria_ID);
            return View(post_Update);
        }

        // POST: Post_Update/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Post_Update_ID,About_Malaria_ID,Post_Description")] Post_Update post_Update)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post_Update).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.About_Malaria_ID = new SelectList(db.About_Malaria, "About_Malaria_ID", "Malaria_Description", post_Update.About_Malaria_ID);
            return View(post_Update);
        }

        // GET: Post_Update/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post_Update post_Update = db.Post_Update.Find(id);
            if (post_Update == null)
            {
                return HttpNotFound();
            }
            return View(post_Update);
        }

        // POST: Post_Update/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post_Update post_Update = db.Post_Update.Find(id);
            db.Post_Update.Remove(post_Update);
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
