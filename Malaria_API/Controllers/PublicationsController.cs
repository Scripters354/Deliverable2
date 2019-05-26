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
    public class PublicationsController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();


        [Route("api/Publications/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getPublicationsreturnList(db.Publications.ToList());
        }

        private List<dynamic> getPublicationsreturnList(List<Publication> forPublications)
        {
            List<dynamic> dynamicPublications = new List<dynamic>();

            foreach (Publication publication in forPublications)
            {
                dynamic APublication = new ExpandoObject();
                APublication.Publication_ID = publication.Publication_ID;
                APublication.Publication_Description = publication.Publication_Description;
                APublication.Publication_Link = publication.Publication_Link;
                dynamicPublications.Add(APublication);
            }

            return dynamicPublications;
        }
        // GET: api/Publications
        public IQueryable<Publication> GetPublications()
        {
            return db.Publications;
        }

        // GET: h
        [ResponseType(typeof(Publication))]
        public IHttpActionResult GetPublication(int id)
        {
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        // PUT: api/Publications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublication(int id, Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publication.Publication_ID)
            {
                return BadRequest();
            }

            db.Entry(publication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // POST: api/Publications
        [ResponseType(typeof(Publication))]
        public IHttpActionResult PostPublication(Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Publications.Add(publication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = publication.Publication_ID }, publication);
        }

        // DELETE: api/Publications/5
        [ResponseType(typeof(Publication))]
        public IHttpActionResult DeletePublication(int id)
        {
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            db.Publications.Remove(publication);
            db.SaveChanges();

            return Ok(publication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicationExists(int id)
        {
            return db.Publications.Count(e => e.Publication_ID == id) > 0;
        }
    }
}