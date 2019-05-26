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
    public class FAQsController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();


        [Route("api/FAQ/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getAboutreturnList(db.FAQs.ToList());
        }

        private List<dynamic> getAboutreturnList(List<FAQ> forAboutMalaria)
        {
            List<dynamic> dynamicAboutMalaria = new List<dynamic>();

            foreach (FAQ faq in forAboutMalaria)
            {
                dynamic x = new ExpandoObject();
                x.FAQ_ID = faq.FAQ_ID;
                x.FAQ_Question = faq.FAQ_Question;
                x.FAQ_Answer = faq.FAQ_Answer;
                dynamicAboutMalaria.Add(x);
            }

            return dynamicAboutMalaria;
        }

        /*
        public IQueryable<FAQ> GetFAQs()
        {
            return db.FAQs;
        }

        // GET: api/FAQs/5
        [ResponseType(typeof(FAQ))]
        public IHttpActionResult GetFAQ(int id)
        {
            FAQ fAQ = db.FAQs.Find(id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return Ok(fAQ);
        }
        */

        // PUT: api/FAQs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFAQ(int id, FAQ fAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fAQ.FAQ_ID)
            {
                return BadRequest();
            }

            db.Entry(fAQ).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAQExists(id))
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

        // POST: api/FAQs
        [ResponseType(typeof(FAQ))]
        public IHttpActionResult PostFAQ(FAQ fAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FAQs.Add(fAQ);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fAQ.FAQ_ID }, fAQ);
        }

        // DELETE: api/FAQs/5
        [ResponseType(typeof(FAQ))]
        public IHttpActionResult DeleteFAQ(int id)
        {
            FAQ fAQ = db.FAQs.Find(id);
            if (fAQ == null)
            {
                return NotFound();
            }

            db.FAQs.Remove(fAQ);
            db.SaveChanges();

            return Ok(fAQ);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FAQExists(int id)
        {
            return db.FAQs.Count(e => e.FAQ_ID == id) > 0;
        }
    }
}