using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Malaria_API.Models;


namespace Malaria_API.Controllers
{
    public class Post_UpdateController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();

        [Route("api/Post_Update/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getAboutreturnList(db.Post_Update.ToList());
        }

        private List<dynamic> getAboutreturnList(List<Post_Update> forPostUpdate)
        {
            List<dynamic> dynamicPost = new List<dynamic>();

            foreach (Post_Update poster in forPostUpdate)
            {
                dynamic dynaPost = new ExpandoObject();
                dynaPost.PostUpdate_ID = poster.Post_Update_ID;
                dynaPost.Post_description = poster.Post_Description;
                dynamicPost.Add(dynaPost);
            }

            return dynamicPost;
        }
        // GET: api/Post_Update
        //public IQueryable<Post_Update> GetPost_Update()
        //{
        //    return db.Post_Update;
        //}

        // GET: api/Post_Update/5
        [ResponseType(typeof(Post_Update))]
        public IHttpActionResult GetPost_Update(int id)
        {
            Post_Update post_Update = db.Post_Update.Find(id);
            if (post_Update == null)
            {
                return NotFound();
            }

            return Ok(post_Update);
        }

        // PUT: api/Post_Update/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost_Update(int id, Post_Update post_Update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post_Update.Post_Update_ID)
            {
                return BadRequest();
            }

            db.Entry(post_Update).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Post_UpdateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Post_Update
        [ResponseType(typeof(Post_Update))]
        public IHttpActionResult PostPost_Update(Post_Update post_Update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Post_Update.Add(post_Update);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post_Update.Post_Update_ID }, post_Update);
        }

        // DELETE: api/Post_Update/5
        [ResponseType(typeof(Post_Update))]
        public IHttpActionResult DeletePost_Update(int id)
        {
            Post_Update post_Update = db.Post_Update.Find(id);
            if (post_Update == null)
            {
                return NotFound();
            }

            db.Post_Update.Remove(post_Update);
            db.SaveChanges();

            return Ok(post_Update);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Post_UpdateExists(int id)
        {
            return db.Post_Update.Count(e => e.Post_Update_ID == id) > 0;
        }
    }
}