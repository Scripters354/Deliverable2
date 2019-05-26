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
    public class SymptomsController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();

        [Route("api/Symptoms/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getAboutreturnList(db.Symptoms.ToList());
        }

        private List<dynamic> getAboutreturnList(List<Symptom> forAboutMalaria)
        {
            List<dynamic> dynamicAboutMalaria = new List<dynamic>();

            foreach (Symptom about_Malaria in forAboutMalaria)
            {
                dynamic AMalaria = new ExpandoObject();
                AMalaria.Symptom_ID = about_Malaria.Symptom_ID;
                AMalaria.Symptom_Name = about_Malaria.Symptom_Name;
                AMalaria.Symptom_Description = about_Malaria.Symptom_Description;
                dynamicAboutMalaria.Add(AMalaria);
            }

            return dynamicAboutMalaria;
        }
        /* // GET: api/Symptoms
         public IQueryable<Symptom> GetSymptoms()
         {
             return db.Symptoms;
         }

         // GET: api/Symptoms/5
         [ResponseType(typeof(Symptom))]
         public IHttpActionResult GetSymptom(int id)
         {
             Symptom symptom = db.Symptoms.Find(id);
             if (symptom == null)
             {
                 return NotFound();
             }

             return Ok(symptom);
         }
         */
        // PUT: api/Symptoms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSymptom(int id, Symptom symptom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != symptom.Symptom_ID)
            {
                return BadRequest();
            }

            db.Entry(symptom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymptomExists(id))
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

        // POST: api/Symptoms
        [ResponseType(typeof(Symptom))]
        public IHttpActionResult PostSymptom(Symptom symptom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Symptoms.Add(symptom);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = symptom.Symptom_ID }, symptom);
        }

        // DELETE: api/Symptoms/5
        [ResponseType(typeof(Symptom))]
        public IHttpActionResult DeleteSymptom(int id)
        {
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return NotFound();
            }

            db.Symptoms.Remove(symptom);
            db.SaveChanges();

            return Ok(symptom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SymptomExists(int id)
        {
            return db.Symptoms.Count(e => e.Symptom_ID == id) > 0;
        }
    }
}