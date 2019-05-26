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
    public class CausesController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();

        [Route("api/Causes/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getAboutreturnList(db.Causes.ToList());
        }

        private List<dynamic> getAboutreturnList(List<Cause> forAboutMalaria)
        {
            List<dynamic> dynamicAboutMalaria = new List<dynamic>();

            foreach (Cause cause in forAboutMalaria)
            {
                dynamic x = new ExpandoObject();
                x.Cause_ID = cause.Cause_ID;
                x.Cause_Name = cause.Cause_Name;
                x.Cause_Description = cause.Cause_Description;
                dynamicAboutMalaria.Add(x);
            }

            return dynamicAboutMalaria;
        }
        /*// GET: api/Causes
        public IQueryable<Cause> GetCauses()
        {
            return db.Causes;
        }

        // GET: api/Causes/5
        [ResponseType(typeof(Cause))]
        public IHttpActionResult GetCause(int id)
        {
            Cause cause = db.Causes.Find(id);
            if (cause == null)
            {
                return NotFound();
            }

            return Ok(cause);
        }*/

        // PUT: api/Causes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCause(int id, Cause cause)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cause.Cause_ID)
            {
                return BadRequest();
            }

            db.Entry(cause).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauseExists(id))
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

        // POST: api/Causes
        [ResponseType(typeof(Cause))]
        public IHttpActionResult PostCause(Cause cause)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Causes.Add(cause);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cause.Cause_ID }, cause);
        }

        // DELETE: api/Causes/5
        [ResponseType(typeof(Cause))]
        public IHttpActionResult DeleteCause(int id)
        {
            Cause cause = db.Causes.Find(id);
            if (cause == null)
            {
                return NotFound();
            }

            db.Causes.Remove(cause);
            db.SaveChanges();

            return Ok(cause);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CauseExists(int id)
        {
            return db.Causes.Count(e => e.Cause_ID == id) > 0;
        }
    }
}